
// tslint:disable-next-line:interface-name
export interface PersonEntity {
    id: number;
    firstName: string;
    lastName: string;
    age: number;
}

export function isPerson(person: PersonEntity): person is PersonEntity {
    const arg = (person as PersonEntity);
    return arg.firstName !== undefined
        && arg.lastName !== undefined
        && arg.age !== undefined;
}


