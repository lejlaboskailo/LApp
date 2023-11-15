import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../mojConfig";
import {Login} from "./view-models/loginVm";
import {Router} from "@angular/router";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './Login.component.html',
  styleUrls: ['./Login.component.css']
})
export class LoginComponent implements OnInit {
  prijava : Login = new Login();
  zapamtiMe : boolean=true;
  fieldText: boolean=true;
  validiranoKorisnickoIme: boolean = false;
  validiranaLozinka : boolean = false;

  constructor(private httpKlijent : HttpClient, private router : Router) {
  }

  ngOnInit(): void {
  }

  posaljiPodatke() {
    if (this.validiranoKorisnickoIme && this.validiranaLozinka) {
      this.httpKlijent.post(MojConfig.adresa_servera + '/AutentifikacijaKontroler/Login', this.prijava)
        .subscribe((response: any) => {
            if (response.isLogiran) {
              this.router.navigate(['/proizvod']);
            } else {
              AutentifikacijaHelper.setLoginInfo(null);
              swal.fire({
                title:'Error',
                text:'User nije pronadjen, provjerite korisnicko ime i lozinku!',
                icon: 'error',
              });
            }
          }
        );
    }
  }

  provjeriKorisnickoIme(polje : any) {
    if (polje.invalid && (polje.dirty || polje.touched)){
      if (polje.errors?.['required']){
        this.validiranoKorisnickoIme = false;
        return 'Niste popunili ovo polje!';
      }
      else {
        this.validiranoKorisnickoIme = true;
        return '';
      }
    }
    if (this.prijava.KorisnickoIme != null && this.prijava.KorisnickoIme.length > 0) this.validiranoKorisnickoIme = true;
    return 'Obavezno polje za unos';
  }

  provjeriLozinku(polje : any) {
    if (polje.invalid && (polje.dirty || polje.touched)){
      if (polje.errors?.['required']){
        this.validiranaLozinka = false;
        return 'Niste popunili ovo polje!';
      }
      else {
        this.validiranaLozinka = true;
        return '';
      }
    }
    if (this.prijava.Lozinka != null && this.prijava.Lozinka.length > 0) this.validiranaLozinka = true;
    return 'Obavezno polje za unos';
  }
}
