import { Interval } from './value-objects/interval';

export class Department {
    id: number;
    name: string;
    weightCriteria: Interval;
    valueCriteria: Interval;

    constructor() {
        this.weightCriteria = new Interval();
        this.valueCriteria = new Interval();
    }
}
