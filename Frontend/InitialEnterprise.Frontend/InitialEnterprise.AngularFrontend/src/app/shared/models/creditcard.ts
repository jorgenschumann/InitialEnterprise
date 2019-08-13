export class CreditCard {
  constructor( public id: string,
               public  personId: string,
               public  creditCardType: string,
               public  cardNumber: string,
               public expireMonth: string,
               public expireYear: string,
             ) {}
 }

export class CreditCardType {
  constructor( public id: string,
               public  name: string
             ) {}
 }
