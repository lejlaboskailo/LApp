
export class LoginInformacije {
  autentifikacijaToken!:        AutentifikacijaToken;
  isLogiran:                   boolean=false;
  isPermisijaKorisnik:         boolean=false;
}

export interface AutentifikacijaToken {
  id:                   number;
  vrijednost:           string;
  korisnickiNalogId:    number;
  korisnickiNalog:      KorisnickiNalog;
  vrijemeEvidentiranja: Date;
  ipAdresa:             string;
}

export interface KorisnickiNalog {
  id:                 number;
  korisnickoIme:      string;

}
