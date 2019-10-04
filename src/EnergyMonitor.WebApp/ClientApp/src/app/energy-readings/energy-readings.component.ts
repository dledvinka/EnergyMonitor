import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-energy-readings',
  templateUrl: './energy-readings.component.html',
  styleUrls: ['./energy-readings.component.css']
})
export class EnergyReadingsComponent implements OnInit {

  public energyReadings: EnergyReading[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    const url = this.baseUrl + 'energyreading';
    console.log('url', url);
    this.http.get<EnergyReading[]>(this.baseUrl + 'energyreading').subscribe(result => {
      this.energyReadings = result;
    }, error => console.error(error));
  }
}

interface EnergyReading {
  id: number;
}
