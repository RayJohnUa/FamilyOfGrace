import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiHelper } from 'src/app/helpers/api.helper';

@Injectable({
  providedIn: 'root'
})
export class HomeGroupService {

  constructor(private http: HttpClient, private _apiHelper: ApiHelper) { }

  get() {
    return this.http.get(this._apiHelper.HomeGroupList);
  }

  getSingle(id) {
    return this.http.get(this._apiHelper.HomeGroupGet + "?id=" + id);
  }

  delete(id) {
    return this.http.delete(this._apiHelper.HomeGroupDelete + "?id=" + id);
  }

  update(id, mailing) {
    return this.http.put(this._apiHelper.MailingUpdate + "?id=" + id, mailing);
  }

  add(homegroup) {
    return this.http.post(this._apiHelper.HomeGroupAdd, homegroup);
  }
}
