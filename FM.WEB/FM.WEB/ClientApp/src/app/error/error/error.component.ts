import { Component, OnInit } from '@angular/core';
import { ErrorService } from '../error.service';
import { GlobalError } from '../globalError';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})
export class ErrorComponent implements OnInit {
  constructor(private _errorService: ErrorService) {
    this._errorService.globalErrorEmitter$.subscribe(x => this.onError(x));
    
  }

  public  model: GlobalError[] = [];
  
  public onError(x: GlobalError) {
    this.model.push(x);
  }
  delete(item) {
    const index: number = this.model.indexOf(item);
    if (index !== -1) {
      this.model.splice(index, 1);
    } 
  }
  ngOnInit() {
  }

}
