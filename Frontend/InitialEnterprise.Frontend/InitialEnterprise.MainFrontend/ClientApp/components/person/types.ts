import { PersonEntity } from "../test/PersonEntity";
import { ValidationResult } from "../types";

export type PersonFormButtonType = 'edit' | 'add' | undefined;


export interface PeopleInterface {
    people: Person[] | undefined;
}

export interface PersonFormState {
    person: Person;   
    validationResult: ValidationResult;
}

export interface EditDeleteButtonClicks {
    deleteClick: (person: Person) => void;
    editClick: (person: Person) => void;
}

export interface Person {   
    Id: string;
    Title: string;
    FirstName: string;
    LastName: string;
    PersonType: string;
    //NameStyle: boolean;
    //MiddleName: string;
    //Suffix: string;
    //EmailPromotion: number;
    EmailAddresses: EmailAddress[]
}

export interface EmailAddress {
    Id: string;
    PersonId: string;
    MailAddress: string;
}



