import { Injectable } from '@angular/core';

@Injectable()
export class ApiHelper {
  //private readonly _baseUrl: string = 'http://famofgrace.azurewebsites.net';
  private readonly _baseUrl: string = 'http://localhost:49412';

  public readonly Auth = this._baseUrl + "/api/auth/token";

  public readonly PersonList = this._baseUrl + "/api/Person/List";
  public readonly PersonDelete = this._baseUrl + "/api/Person/Delete";
  public readonly PersonUpdate = this._baseUrl + "/api/Person/Update";
  public readonly PersonAdd = this._baseUrl + "/api/Person/Add";
  public readonly AsignToGroupPerson = this._baseUrl + "/api/Person/AsignToGroup";

  public readonly MailingList = this._baseUrl + "/api/Mailing/List";
  public readonly MailingGet = this._baseUrl + "/api/Mailing/Get";
  public readonly MailingUpdate = this._baseUrl + "/api/Mailing/Update";
  public readonly MailingAdd = this._baseUrl + "/api/Mailing/Add";
  public readonly MailingDelete = this._baseUrl + "/api/Mailing/Delete";

  public readonly HomeGroupList = this._baseUrl + "/api/HomeGroup/List";
  public readonly HomeGroupAdd = this._baseUrl + "/api/HomeGroup/Add";
  public readonly HomeGroupDelete = this._baseUrl + "/api/HomeGroup/Delete";
  public readonly HomeGroupGet = this._baseUrl + "/api/HomeGroup/Get";

  
}
