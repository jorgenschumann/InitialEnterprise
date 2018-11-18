import { PersonEntity } from "../test/PersonEntity";
import { List } from 'linqts';

export type PersonFormButtonType = 'edit' | 'add' | undefined;


export interface Model<TEntity> {
    Entity: TEntity;
    ValidationResult: ValidationResult;
}

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
    FirstName: string;
    LastName: string;
}

export interface MailAdresses {
    Id: string;
    PersonId: string;
    MailAdress: string;
}

export interface ValidationResult {
    IsValid: boolean;
    Errors: ValidationFailure[];       
}

export interface ValidationFailure { 
    PropertyName: string;
    ErrorMessage: string;
    ErrorCode: string;
}

