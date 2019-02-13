/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UserSigninService } from './user-signin.service';

describe('Service: UserSignin', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UserSigninService]
    });
  });

  it('should ...', inject([UserSigninService], (service: UserSigninService) => {
    expect(service).toBeTruthy();
  }));
});
