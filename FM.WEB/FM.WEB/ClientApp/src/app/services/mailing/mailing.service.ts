import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiHelper } from 'src/app/helpers/api.helper';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class MailingService {

  constructor(private http: HttpClient, private _apiHelper: ApiHelper) { }

  getMailings() {
    return this.http.get(this._apiHelper.MailingList);
  }

  getSingle(id) {
    return this.http.get(this._apiHelper.MailingGet + "?id=" + id);
  }

  delete(id) {
    return this.http.delete(this._apiHelper.MailingDelete + "?id=" + id);
  }

  update(id, mailing) {
    return this.http.put(this._apiHelper.MailingUpdate + "?id=" + id, mailing);
  }

  send(id, mailing) {
    return this.http.post(this._apiHelper.MailingSend + "?id=" + id, mailing);
  }

  add(mailing) {
    return this.http.post(this._apiHelper.MailingAdd, mailing);
  }
}
