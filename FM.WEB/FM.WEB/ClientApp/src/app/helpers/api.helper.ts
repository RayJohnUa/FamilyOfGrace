import { Injectable } from '@angular/core';

@Injectable()
export class ApiHelper {
  private readonly  _baseUrl: string = 'http://localhost:49412';

  public readonly  Auth = this._baseUrl + "/api/auth/token";

}
