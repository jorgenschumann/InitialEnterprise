import { CreditCard } from './../models/creditcard';
import { Guid } from '../utils/guid';
import { Injectable } from '@angular/core';
@Injectable({ providedIn: 'root' })

export class CreditCardFactory {
  public static empty(personId: string): CreditCard {
    return new CreditCard(Guid.emptyGuid(), personId, null, '', '', '', Guid.emptyGuid());
  }
}
