import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import 'rxjs/add/operator/map'

@Injectable()
export class AuthService {
  constructor(private http: HttpClient) { }

  login(username: string, password: string) {

    let headers = new HttpHeaders();
    headers.append('Access-Control-Allow-Origin', '*')

      this.http.post("http://localhost:51379/api/auth/token", null, { headers : headers}).subscribe(x => {
      console.log(x);
    });
  }

  logout() {
    localStorage.removeItem('currentUser');
  }
}
