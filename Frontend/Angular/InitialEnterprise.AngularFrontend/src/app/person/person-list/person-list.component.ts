import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/shared/models/person.types';
import { PersonService } from 'src/app/shared/services/person.service';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit {
  people: Array<Person>;

  constructor(
    private personService: PersonService) {
    }

  ngOnInit() {
    this.personService.list()
    .subscribe(res => {
      this.people  = res;
    }, err => {
      console.log(err);
    });
  }
}


