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
  model: any = {};
  persons: any;

  constructor(private route: ActivatedRoute,
    private _mailingService: MailingService,
    private _personService: PersonService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
    });
    this._mailingService.getSingle(this.id).subscribe(x => {
      this.model = x;
    });
    this._personService.getPerson().subscribe(x => {
      this.toppingList = x;
    });
  }

  compareFn(first, second) {
    return first.id == second.id;
  }

  toppings = new FormControl();
  toppingList: any;

  save() {
    this._mailingService.update(this.id,
      {
        Persons: this.toppings.value,
        Name: this.model.name,
        Content: this.model.content
      }).subscribe(x => {
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
