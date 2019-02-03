import { Component, OnInit, ViewChild } from '@angular/core';
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
  dataSource: any;

  constructor(private _mailingService: MailingService , private errorService: ErrorService) {
  }

  ngOnInit() {
    this._mailingService.getMailings().subscribe(x => {
      this.dataSource = x;
    });
  }

}
