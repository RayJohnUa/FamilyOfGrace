import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApiHelper } from 'src/app/helpers/api.helper';
import { Observable } from 'rxjs';
import { IToken } from 'src/app/login/login.component';
//import 'rxjs/add/operator/map'

@Injectable()
export class AuthService {
  constructor(private http: HttpClient, private _apiHelper:ApiHelper) { }

  login(username: string, password: string): Observable<any>{

    return this.http.post(this._apiHelper.Auth,
      { email: username, password: password });
  }

  public getToken(): string {
    return localStorage.getItem('Token');
  }


  logout() {
    localStorage.removeItem('Token');
  }
}
