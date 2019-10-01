import { Interval } from './value-objects/interval';

export class Department {
    id: number;
    name: string;
    weightCriteria: Interval;
    valueCriteria: Interval;
}
