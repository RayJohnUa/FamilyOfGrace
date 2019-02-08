import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiHelper } from 'src/app/helpers/api.helper';
import { Observable, of } from 'rxjs';

@Injectable()
export class PersonService {

  constructor(private http: HttpClient, private _apiHelper: ApiHelper) { }

  getPerson() {
    return this.http.get(this._apiHelper.PersonList);
  }

  deletePerson(id) {
    return this.http.delete(this._apiHelper.PersonDelete + "?id=" + id);
  }

  updatePerson(id , person) {
    return this.http.put(this._apiHelper.PersonUpdate + "?id=" + id, person);
  }

  addPerson(person) {
    return this.http.post(this._apiHelper.PersonAdd, person);
  }

  assignePerson(assigne) {
    return this.http.post(this._apiHelper.AsignToGroupPerson, assigne);
  }
  
}
