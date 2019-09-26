import { Person } from './person';

export class Parcel {
    sender: Person;
    receipient: Person;
    weight: number;
    value: number;

    constructor() {
        this.sender = new Person();
        this.receipient = new Person();
    }
}
