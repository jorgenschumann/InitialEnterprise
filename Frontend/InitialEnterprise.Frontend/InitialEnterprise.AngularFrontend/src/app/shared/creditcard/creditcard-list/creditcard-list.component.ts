import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CreditCard } from '../../models/creditcard';
import { Person } from '../../models/person.types';
import { Guid } from '../../utils/guid';

@Component({
  selector: 'app-creditcard-list',
  templateUrl: './creditcard-list.component.html',
  styleUrls: ['./creditcard-list.component.css']
})
export class CreditCardListComponent implements OnInit {
  @Input() creditCards: CreditCard[];
  @Input() person: Person;

  constructor(
    private router: Router,
    private route: ActivatedRoute) {
    }


  ngOnInit() {
  }

  create() {
    this.router.navigate(['/persons', this.person.id, 'creditCards', Guid.emptyGuid()], { relativeTo: this.route });
 }

}
