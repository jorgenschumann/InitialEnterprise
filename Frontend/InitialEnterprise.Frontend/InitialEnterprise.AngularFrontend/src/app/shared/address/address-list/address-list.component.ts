import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
import { AddressService } from '../../services/address.service';
import { Address } from '../../models/address';
import { Person } from '../../models/person.types';
import { Guid } from '../../utils/guid';

@Component({
  selector: 'app-address-list',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.css']
})

export class AddressListComponent implements OnInit {
   @Input() addresses: Address[];
   @Input() person: Person;



  constructor(
    private router: Router,
    private route: ActivatedRoute) {
    }

  ngOnInit() {
  }

  create() {
     this.router.navigate(['/persons', this.person.id, 'addresses', Guid.emptyGuid()], { relativeTo: this.route });
  }
}




