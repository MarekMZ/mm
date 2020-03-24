import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { KontoInformacje } from './KontoInformacje';

@Component({
  selector: 'app-konto',
  templateUrl: './konto.component.html'
})
export class KontoComponent {


  kontoNr: number;
  kwota: number;
  url: string;
  info: KontoInformacje;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }


  wplac() {
    let adres = this.url + 'api/konto/wplac/' + this.kontoNr + '/' + this.kwota;
    console.log(adres);
    this.http.get(adres).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
    this.informacje();
  }

  wyplac() {
    let adres = this.url + 'api/konto/wyplac/' + this.kontoNr + '/' + this.kwota;
    console.log(adres);
    this.http.get(adres).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }

  informacje() {
    let adres = this.url + 'api/konto/info/' + this.kontoNr;
    console.log(adres);
    this.http.get<KontoInformacje>(adres).subscribe(result => {
      this.info = result;
      console.log(result);
    }, error => console.error(error));

  }

}
