import { Address } from './address';
import { MailAddress } from './mailaddress';

export class Person {
  id: string;
  personType: string ;
  nameStyle: string;
  title: string;
  firstName: string;
  middleName: string;
  lastName: string;
  suffix: string;
  emailPromotion: string;
  emailAddresses: MailAddress[];
  addresses: Address[];
}


