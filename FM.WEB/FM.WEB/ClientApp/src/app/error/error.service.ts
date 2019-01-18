import { EventEmitter, Injectable } from '@angular/core';
import { GlobalError } from './globalError';

@Injectable()
export class ErrorService{

  constructor() {
    this.globalErrorEmitter$ = new EventEmitter();
  }

  public globalErrorEmitter$: EventEmitter<GlobalError>;

  public pushError(error:GlobalError) {
    this.globalErrorEmitter$.emit(error);
  }

  public pushStringError(error:string) {
    this.globalErrorEmitter$.emit(new GlobalError(error));
  }
}
