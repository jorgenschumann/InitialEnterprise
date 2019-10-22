/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MailaddressService } from './mailaddress.service';

describe('Service: Mailaddress', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MailaddressService]
    });
  });

  it('should ...', inject([MailaddressService], (service: MailaddressService) => {
    expect(service).toBeTruthy();
  }));
});
