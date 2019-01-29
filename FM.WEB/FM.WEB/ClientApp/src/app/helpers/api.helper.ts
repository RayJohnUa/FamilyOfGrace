import { Injectable } from '@angular/core';

@Injectable()
export class ApiHelper {
  private readonly  _baseUrl: string = 'http://localhost:49412';

  public readonly Auth = this._baseUrl + "/api/auth/token";

  public readonly PersonList = this._baseUrl + "/api/Person/List";
  public readonly PersonDelete = this._baseUrl + "/api/Person/Delete";
  public readonly PersonUpdate = this._baseUrl + "/api/Person/Update";
  public readonly PersonAdd = this._baseUrl + "/api/Person/Add";

  public readonly MailingList = this._baseUrl + "/api/Mailing/List";
  public readonly MailingGet = this._baseUrl + "/api/Mailing/Get";
  public readonly MailingUpdate = this._baseUrl + "/api/Mailing/Update";


}
