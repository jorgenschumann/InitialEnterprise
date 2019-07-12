import { Address } from '../models/address';
import { Guid } from '../utils/guid';
import { Injectable } from '@angular/core';

export class AddressFactory {
  public static empty(personId: string): Address {
   return new Address(Guid.emptyGuid(), personId, '', '', '', '', '', '', false );
 }
}
