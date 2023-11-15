import {Component, OnInit} from '@angular/core';
import {MojConfig} from "./mojConfig";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  constructor(private httpKlijent: HttpClient, private router: Router,) {
  }

  logButton() {
    let token = MojConfig;
    this.router.navigateByUrl("/Login");
  }

  ngOnInit(): void {
  }
}
