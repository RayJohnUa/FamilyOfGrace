import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MailingService } from '../services/mailing/mailing.service';
import { Validators, FormControl } from '@angular/forms';
import { PersonService } from '../services/person/person.service';


@Component({
  selector: 'app-mailing-single',
  templateUrl: './mailing-single.component.html',
  styleUrls: ['./mailing-single.component.css']
})
export class MailingSingleComponent implements OnInit, OnDestroy {
  id: number;
  private sub: any;
  datasource: any;
  persons: any;

  constructor(private route: ActivatedRoute,
    private _mailingService: MailingService,
    private _personService: PersonService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
    });
    this._mailingService.getSingle(this.id).subscribe(x => {
      this.datasource = x;
    });
    this._personService.getPerson().subscribe(x => {
      this.toppingList = x;
    });
  }

  toppings = new FormControl();
  toppingList: any;

  save(persons) {
    this.datasource.Persons = this.toppings.value;
    console.log(this.datasource);
    this._mailingService.update(this.id, this.datasource).subscribe(x => {
      console.log(x);
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
