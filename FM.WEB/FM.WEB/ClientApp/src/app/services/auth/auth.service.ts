import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApiHelper } from 'src/app/helpers/api.helper';
import { Observable } from 'rxjs';
//import 'rxjs/add/operator/map'

@Injectable()
export class AuthService {
  constructor(private http: HttpClient, private _apiHelper:ApiHelper) { }

  login(username: string, password: string){
    let headers = new HttpHeaders();
    headers.append('Access-Control-Allow-Origin', '*');

    return this.http.post(this._apiHelper.Auth,
      { email: username, password: password },
      { headers: headers });
  }

  logout() {
    localStorage.removeItem('logedUser');
  }
}
