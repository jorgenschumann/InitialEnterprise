export type PersonFormButtonType = 'edit' | 'add' | undefined;

// tslint:disable-next-line:interface-name
export interface PeopleInterface {
    people: Person[] | undefined;
}

// tslint:disable-next-line:interface-name
export interface PersonInterface {
    person: Person ;
}

// tslint:disable-next-line:interface-name
export interface EditDeleteButtonClicks {
    deleteClick: (person: Person) => void;
    editClick: (person: Person) => void;
}

// tslint:disable-next-line:interface-name
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

export function isPerson(person: Person): person is Person {
    const arg = (person as Person);
    return arg.FirstName !== undefined
        && arg.FirstName !== undefined;
}
