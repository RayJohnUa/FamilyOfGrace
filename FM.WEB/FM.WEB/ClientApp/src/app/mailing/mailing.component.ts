import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { PersonService } from '../services/person/person.service';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ErrorService } from '../error/error.service';
import { MailingService } from '../services/mailing/mailing.service';



@Component({
  selector: 'app-mailing',
  templateUrl: './mailing.component.html',
  styleUrls: ['./mailing.component.css']
})
export class MailingComponent implements OnInit {
  dataSource: any = [];
  model: any = {};
  constructor(private _mailingService: MailingService , private errorService: ErrorService) {
  }

  ngOnInit() {
    this._mailingService.getMailings().subscribe(x => {
      this.dataSource = x;
    });
  }

  create() {
    this._mailingService.add(this.model).subscribe(x => {
      this.dataSource.push(
        { name: this.model.name, content: this.model.content, persons: Array(0) }
      );
    });
  }

  delete(id) {
    this._mailingService.delete(id).subscribe(x => {
      let index = this.dataSource.findIndex(d => d.id === id);
      this.dataSource.splice(index, 1);
    })
  }

}

