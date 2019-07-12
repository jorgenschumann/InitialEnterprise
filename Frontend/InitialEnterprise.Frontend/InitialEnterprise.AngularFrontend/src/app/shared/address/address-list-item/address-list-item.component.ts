import { AddressService } from './../../services/address.service';
import { Component, OnInit, Input } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmDialogBuilder } from '../../components/confirm-dialog/confirm-dialog-builder';
import { Address } from '../../models/address';
import { ArrayUtils } from '../../utils/arrayUtils';

@Component({
  selector: 'app-address-list-item',
  templateUrl: './address-list-item.component.html',
  styleUrls: ['./address-list-item.component.css']
})

export class AddressListItemComponent implements OnInit {
  @Input() address: Address;
  @Input() addresses: Address[];

  constructor(
    private addressService: AddressService,
    private modalService: NgbModal) {
      this.addressService.RootEntityEndpointFragment = 'person';
    }

  ngOnInit( ) {
  }

  delete(address: Address) {
    const modal = ConfirmDialogBuilder.deleteConfirmBox(
    this.modalService, 'Delete Address', `${address.street}  ${address.number}, ${address.zip} ${address.city} `);
    modal.result.then((result) => {
        if (result === 'confirm') {
          this.addressService.delete(this.address.personId, this.address)
          .subscribe(() => {
          }, err => {
            console.log(err);
          });
          ArrayUtils.removeFromArray(this.addresses, address);
        }
    });
  }
}
