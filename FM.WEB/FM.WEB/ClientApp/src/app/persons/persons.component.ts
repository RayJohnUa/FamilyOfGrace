import { Component, OnInit, ViewChild } from '@angular/core';
import { PersonService } from '../services/person/person.service';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ErrorService } from '../error/error.service';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css']
})
export class PersonsComponent implements OnInit {
  dataSource: any;

  constructor(private _personService: PersonService , private errorService: ErrorService) {
  }

  settings = {
    delete: {
      confirmDelete: true,
    },
    add: {
      confirmCreate: true,
    },
    edit: {
      confirmSave: true,
    },
    columns: {
      id: {
        title: 'ІД',
        editable: false,
        addable: false,
      },
      firstName: {
        title: 'Імя'
      },
      lastName: {
        title: 'Фамілія'
      },
      telephone: {
        title: 'Телефон'
      }
    },
    pager: {
      perPage: 5
    },
  };

  ngOnInit() {
    this._personService.getPerson().subscribe(x => {
      this.dataSource = x;
    });
  }

  onDeleteConfirm(event) {
    this._personService.deletePerson(event.data.id).subscribe(x => {
      if(x) {
        event.confirm.resolve();
      }
    });
  }

  onSaveConfirm(event) {
    if (this.validation(event.newData)) {
      this._personService.updatePerson(event.newData.id, event.newData).subscribe(x => {
        if (x) {
          event.confirm.resolve(event.newData);
        }
      });
    }
  }

  onCreateConfirm(event) {
    if (this.validation(event.newData)) {
      event.newData.id = 0;
      this._personService.addPerson(event.newData).subscribe(x => {
        if (x.isSuccess) {
          event.newData.id = x.id;
          event.confirm.resolve(event.newData);
        }
      });
    }
  }


  private validation(person) {
    var phoneno = new RegExp("^[+]380[0-9]{9}");
    if (person) {
      if (person.firstName && person.lastName && phoneno.test(person.telephone)) {
        return true;
      }
    }
    return false;
  }

}
