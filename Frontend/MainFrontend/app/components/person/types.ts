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
    id: string;
    firstName: string;
    lastName: string;
}

export function isPerson(person: Person): person is Person {
    const arg = (person as Person);
    return arg.firstName !== undefined
        && arg.firstName !== undefined;
}
