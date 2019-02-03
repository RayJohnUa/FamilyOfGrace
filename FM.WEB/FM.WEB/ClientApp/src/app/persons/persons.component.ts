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
      Id: {
        title: 'ІД',
        editable: false,
        addable: false,
      },
      FirstName: {
        title: 'Імя'
      },
      LastName: {
        title: 'Фамілія'
      },
      Telephone: {
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
    this._personService.deletePerson(event.data.Id).subscribe(x => {
      if(x) {
        event.confirm.resolve();
      }
    });
  }

  onSaveConfirm(event) {
    if (this.validation(event.newData)) {
      this._personService.updatePerson(event.newData.Id, event.newData).subscribe(x => {
        if (x) {
          event.confirm.resolve(event.newData);
        }
      });
    }
  }

  onCreateConfirm(event) {
    if (this.validation(event.newData)) {
      event.newData.Id = 0;
      this._personService.addPerson(event.newData).subscribe(x => {
          event.confirm.resolve(event.newData);
      });
    }
  }


  private validation(person) {
    var phoneno = new RegExp("^[+]380[0-9]{9}");
    if (person) {
      if (person.FirstName && person.LastName && phoneno.test(person.Telephone)) {
        return true;
      }
    }
    return false;
  }

}
