/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CountryService } from './country.service';

describe('Service: Country', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CountryService]
    });
  });

  it('should ...', inject([CountryService], (service: CountryService) => {
    expect(service).toBeTruthy();
  }));
});
