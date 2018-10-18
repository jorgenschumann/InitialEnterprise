
export interface PersonEntity {
    id: number;
    firstName: string;
    lastName: string;
    age: number;
}

export function isPerson(person: PersonEntity): person is PersonEntity {
    let arg = (person as PersonEntity);
    return arg.firstName !== undefined
        && arg.lastName !== undefined
        && arg.age !== undefined;
}


