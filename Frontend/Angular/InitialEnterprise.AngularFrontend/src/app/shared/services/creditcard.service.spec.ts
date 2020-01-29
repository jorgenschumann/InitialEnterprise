/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CreditcardService } from './creditcard.service';

describe('Service: Creditcard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CreditcardService]
    });
  });

  it('should ...', inject([CreditcardService], (service: CreditcardService) => {
    expect(service).toBeTruthy();
  }));
});
