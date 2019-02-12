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

  constructor(private route: ActivatedRoute, private homeGroupService: HomeGroupService, private _personService: PersonService) { }
  person: any = [];

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
    });

    this.homeGroupService.getSingle(this.id).subscribe(x => {
      this.dataSource = x;
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

  selectionChangeWeek(option , id) {
    console.log(option.option.value)
    console.log(option.option._selected)
    console.log(id);
  }

  delete(id) {
    console.log(id);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
