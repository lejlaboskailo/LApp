import { Component,Input, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../mojConfig";
import {Router} from "@angular/router";
import {Proizvod} from "./view-models/proizvodVM";

@Component({
  selector: 'app-proizvod',
  templateUrl: './proizvod.component.html',
  styleUrls: ['./proizvod.component.css']
})
export class ProizvodComponent implements OnInit {
  public proizvod: any;
  public ProizvodId: any = {};
  public noviProizvod = new Proizvod();
  public fieldText: boolean = true;

  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  ngOnInit(): void {
    this.ucitajPodatke();
  }


  private ucitajPodatke() {
    this.httpKlijent.get(MojConfig.adresa_servera + "/ProizvodKontroler/GetAll", MojConfig.http_opcije()).subscribe((response: any) => {
      this.proizvod = response;
      console.info(this.proizvod);
    });
  }


  public DodajProizvod(stavka: Proizvod) {
    console.info(stavka);
    this.ProizvodId = stavka.id;
    this.httpKlijent.post(MojConfig.adresa_servera + "/ProizvodKontroler/DodajProizvod", stavka, MojConfig.http_opcije())
      .subscribe((response: any) => {
        this.proizvod.push(response);
      }, error => {
        alert(error.error);
      });
  }

  public ObrisiProizvod(stavka: Proizvod) {
    console.info(stavka);
    this.httpKlijent.post(MojConfig.adresa_servera + "/ProizvodKontroler/Delete/" + stavka.id, MojConfig.http_opcije())
      .subscribe((response: any) => {
        this.ucitajPodatke();
      });
  }
}
