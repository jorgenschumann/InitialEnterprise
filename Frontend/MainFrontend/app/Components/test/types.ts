export type PersonFormButtonType = 'edit' | 'add';
import { PersonEntity } from './PersonEntity';

// tslint:disable-next-line:interface-name
export interface PeopleInterface {
    people: PersonEntity[];
}

// tslint:disable-next-line:interface-name
export interface PersonInterface {
    person: PersonEntity;
}

// tslint:disable-next-line:interface-name
export interface EditDeleteButtonClicks {
    deleteClick: (person: PersonEntity) => void;
    editClick: (person: PersonEntity) => void;
}
