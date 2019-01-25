import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { AuthService } from './auth/auth.service';
import { Observable } from 'rxjs';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(public auth: AuthService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var token = this.auth.getToken();
    if (token != null) {
      request = request.clone({
        setHeaders: {
          'Authorization': `Bearer ${token}`,
          'Access-Control-Allow-Origin': '*',
        }
      });
    } else {
      request = request.clone({
        setHeaders: {
          'Access-Control-Allow-Origin': '*',
        }
      });
    }
   

    return next.handle(request);
  }
}
