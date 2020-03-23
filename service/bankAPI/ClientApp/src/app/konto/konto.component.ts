import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-konto',
  templateUrl: './konto.component.html'
})
export class KontoComponent {


  kontoNr: number = 666;
  kwota: number = 200;
  url: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {


    console.log(baseUrl + '><>>>>>>  weatherforecast')
    this.url = baseUrl;



    //http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
    //  this.forecasts = result;
    //}, error => console.error(error));


  }


  wplac() {
    console.log(this.url + '><>>>>>>  wplac' + this.kwota)
    this.http.get(this.url + 'api/konto/wplac/3/4').subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }

  wyplac() {
    console.log(this.url  + '><>>>>>>  wyplac')
  }

}
