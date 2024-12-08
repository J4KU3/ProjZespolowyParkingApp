import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Sector } from '../sector';
import { ParkingSpot } from '../parking-spot';
import { ParkingService } from '../parking.service';
import { Reservation } from '../reservation';
import { FormsModule } from '@angular/forms';
import { concatMap } from 'rxjs';
import { ParkingSpotComponent } from '../parking-spot/parking-spot.component';

@Component({
  selector: 'app-main-container',
  standalone: true,
  imports: [NgFor, NgIf, FormsModule, ParkingSpotComponent],
  templateUrl: './main-container.component.html',
  styleUrl: './main-container.component.css',
})

export class MainContainerComponent implements OnInit {
  sectors: Sector[] = [];
  parkingSpots: ParkingSpot[] = []
  selectedSector?: Sector;
  selectedSpot?: ParkingSpot;
  formInput: {start_Date: string, end_Date: string, start_Time: string, end_Time: string, license_Plate: string} = {
    start_Time: '',
    end_Time: '',
    start_Date: '',
    end_Date: '',
    license_Plate: '',
  }
  
  
  constructor(private parkingService: ParkingService) {}

  selectSector(sector: Sector) {
    this.selectedSector = sector;
    console.log(sector.sector_ID);
    this.selectedSpot = undefined; // Clear the selected spot when changing sector
  }

  selectParkingSpot(spot: ParkingSpot) {
    this.selectedSpot = spot;
  }

  submitReservation(){
    if(!this.selectedSector || !this.selectedSpot){
      return;
    }
    if(this.formInput.start_Time === this.formInput.end_Time){
      return;
    }
    const start_Time = `${this.formInput.start_Date}T${this.formInput.start_Time}:00.000Z`;
    const end_Time = `${this.formInput.end_Date}T${this.formInput.end_Time}:00.000Z`;
    
    const payload: Reservation = {
      start_Time: start_Time,
      end_Time: end_Time,
      license_Plate: this.formInput.license_Plate,
      parking_Lot_ID: this.selectedSector.sector_ID,
      place_Number: this.selectedSpot.place_Number,
    };
    console.log(payload);
    this.parkingService.reserveSpot(payload).subscribe((response) => {
      console.log('Reservation successful:', response);
    });
  }

  ngOnInit() {
    const time = new Date().toTimeString().slice(0,5).toString();
    const date = new Date().toISOString().split('T')[0];
    this.formInput.start_Date = date;
    this.formInput.end_Date = date;
    this.formInput.start_Time = time;
    this.formInput.end_Time = time;

    this.parkingService.getSectors().pipe(
      concatMap((sectors) => {
        this.sectors = sectors;
        return this.parkingService.getPlaces();
      })
    ).subscribe((spots) => {
      this.parkingSpots = spots;
      console.log(this.parkingSpots);
    })
  }
}
