export type PersonFormButtonType = 'edit' | 'add' | undefined;

export interface PeopleInterface {
    people: Person[] | undefined;
}

export interface PersonInterface {
    person: Person ;
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

export function isPerson(person: Person): person is Person {
    let arg = (person as Person);
    return arg.FirstName !== undefined
        && arg.LastName !== undefined;
}
