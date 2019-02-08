import { Component, OnInit } from '@angular/core';
import { HomeGroupService } from '../services/homegroup/home-group.service';
import { ErrorService } from '../error/error.service';

@Component({
  selector: 'app-home-group',
  templateUrl: './home-group.component.html',
  styleUrls: ['./home-group.component.css']
})
export class HomeGroupComponent implements OnInit {

  dataSource: any = [];
  model: any = {};
  constructor(private homeGroupService: HomeGroupService, private errorService: ErrorService) {
  }

  ngOnInit() {
    this.homeGroupService.get().subscribe(x => {
      this.dataSource = x;
    });
  }

  create() {
    this.homeGroupService.add(this.model).subscribe(x => {
      this.dataSource.push(
        { name: this.model.name, people: Array(0) }
      );
    });
  }

  delete(id) {
    this.homeGroupService.delete(id).subscribe(x => {
      let index = this.dataSource.findIndex(d => d.id === id);
      this.dataSource.splice(index, 1);
    })
  }
}
