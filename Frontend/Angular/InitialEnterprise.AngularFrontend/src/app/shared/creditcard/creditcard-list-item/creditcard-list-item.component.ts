import { Component, OnInit, Input } from '@angular/core';
import { CreditCard } from '../../models/creditcard';
import { CreditCardService } from '../../services/creditcard.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmDialogBuilder } from '../../components/confirm-dialog/confirm-dialog-builder';
import { ArrayUtils } from '../../utils/arrayUtils';

@Component({
  selector: 'app-creditcard-list-item',
  templateUrl: './creditcard-list-item.component.html',
  styleUrls: ['./creditcard-list-item.component.css']
})
export class CreditCardListItemComponent {
  @Input() creditCard: CreditCard;
  @Input() creditCards: CreditCard[];

  constructor(
    private creditCardService: CreditCardService,
    private modalService: NgbModal) {
      this.creditCardService.RootEntityEndpointFragment = 'person';
  }

  delete(creditCard: CreditCard) {
    const modal = ConfirmDialogBuilder.deleteConfirmBox(
    this.modalService, 'Delete CreditCard', `${creditCard.creditCardType}, ${creditCard.cardNumber}`);
    modal.result.then((result) => {
        if (result === 'confirm') {
          this.creditCardService.delete(this.creditCard.personId, this.creditCard)
          .subscribe(() => {
          }, err => {
            console.log(err);
          });
          ArrayUtils.removeFromArray(this.creditCards, creditCard);
        }
    });
  }

}
