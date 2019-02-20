import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HomeGroupService } from '../services/homegroup/home-group.service';
import { PersonService } from '../services/person/person.service';

@Component({
  selector: 'app-home-group-details',
  templateUrl: './home-group-details.component.html',
  styleUrls: ['./home-group-details.component.css']
})
export class HomeGroupDetailsComponent implements OnInit, OnDestroy{
  id: number;
  private sub: any;
  dataSource: any = {};
  model: Date = new Date();
  constructor(private route: ActivatedRoute, private homeGroupService: HomeGroupService, private _personService: PersonService) { }
  person: any = [];

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
    });

    this.homeGroupService.getSingle(this.id).subscribe(x => {
      this.dataSource = x;
      console.log(x);
    });

    this._personService.getPerson().subscribe(x => {
      this.person = x;
    });
  }


  compareFn(first, second) {
    return first.id == second.id;
  }

  selectionChange(option) {
    this._personService.assignePerson({
      isAssigne: option.option._selected,
      personId: option.option.value.id,
      groupId: this.id,
    }).subscribe(x => {
      console.log(x);
    });
  }

  send() {
    this.homeGroupService.send(this.id).subscribe(x => {
      console.log(x);
    });
  }

  createWeek() {
    console.log(this.model);
    this.homeGroupService.addWeek(this.id, this.model
  ).subscribe(x => {
    this.dataSource.groupSession.push(x);
    });
  }

  selectionChangeWeek(option, id) {
    this.homeGroupService.asigneToWeek({
      IsAssigne: option.option._selected,
      PersonId: option.option.value.id,
      WeekId : id
    }).subscribe(x => {
      console.log(x);
    });
  }

  delete(id) {
    this.homeGroupService.deleteWeek(id).subscribe(x => {
      this.dataSource.groupSession = this.dataSource.groupSession.filter(item => item.id != id);
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
