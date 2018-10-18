export type PersonFormButtonType = 'edit' | 'add';
import { PersonEntity } from './PersonEntity';

export interface PeopleInterface {
    people: PersonEntity[];
}

export interface PersonInterface {
    person: PersonEntity;
}

export interface EditDeleteButtonClicks {
    deleteClick: (person: PersonEntity) => void;
    editClick:(person: PersonEntity) => void;
}