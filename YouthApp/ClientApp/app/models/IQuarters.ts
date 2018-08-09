export interface IQuarters {
    name: string;
    value: { start: number, end: number }
}

export class Quarters {
    private quarters: IQuarters[];
    constructor() {
        this.quarters = [];
        this.quarters.push({
            name: 'First Quarter',
            value: { start: 1, end: 3 }
        });
        this.quarters.push({
            name: 'Second Quarter',
            value: { start: 1, end: 6 }
        });
        this.quarters.push({
            name: 'Third Quarter',
            value: { start: 1, end: 9 }
        });
        this.quarters.push({
            name: 'Fourth Quarter',
            value: { start: 1, end: 12 }
        });
    }

    getQuarters(): IQuarters[] {
        return this.quarters;
    }
}