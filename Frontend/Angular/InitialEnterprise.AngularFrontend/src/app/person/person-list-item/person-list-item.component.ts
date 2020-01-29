import { Component, OnInit, Input } from '@angular/core';
import { Person } from 'src/app/shared/models/person.types';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'tr.app-person-list-item',
  templateUrl: './person-list-item.component.html',
  styleUrls: ['./person-list-item.component.css']
})

export class PersonListItemComponent {
  @Input() person: Person;
}
