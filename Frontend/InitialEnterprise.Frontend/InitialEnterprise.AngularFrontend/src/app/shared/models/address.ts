import { Country } from './country';

export class Address {
 constructor( public id: string,
              public  personId: string,
              public  street: string,
              // tslint:disable-next-line:variable-name
              public  number: string,
              public country: string,
              public province: string,
              public zip: string,
              public city: string,
              public isPrimary: boolean) {}
}

