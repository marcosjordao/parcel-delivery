export class Interval {
    min: number;
    max: number;
}

export function intervalAsString(interval: Interval) {
    if (interval) {
        if (interval.min && interval.max) {
            return `${interval.min} to ${interval.max}`;
        } else if (interval.min) {
            return `from ${interval.min}`;
        } else if (interval.max) {
            return `up to ${interval.max}`;
        }
    }
    return '-';
}
