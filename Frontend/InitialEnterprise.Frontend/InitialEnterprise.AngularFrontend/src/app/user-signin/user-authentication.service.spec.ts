/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UserAuthenticationService } from './user-authentication.service';

describe('Service: UserAuthentication', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UserAuthenticationService]
    });
  });

  it('should ...', inject([UserAuthenticationService], (service: UserAuthenticationService) => {
    expect(service).toBeTruthy();
  }));
});
