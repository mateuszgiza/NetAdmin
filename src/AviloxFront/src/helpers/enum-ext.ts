import {IssueType} from "../issues/enums";

export interface IEnumTypes {
    name: string;
    value: number;
}

export class EnumExt {
    static getNamesAndValues(e: any): IEnumTypes[] {
        return this.getNames(e).map(n => { return { name: n, value: e[n] as number }; });
    }

    static getNames(e: any): string[] {
        return this.getObjValues(e).filter(v => typeof v === "string") as string[];
    }

    static getValues(e: any): number[] {
        return this.getObjValues(e).filter(v => typeof v === "number") as number[];
    }

    private static getObjValues(e: any): (number | string)[] {
        return Object.keys(e).map(k => e[k]);
    }

    static getName(val: number): string {
        let maps = this.getNamesAndValues(IssueType);
        let elPos = maps.map(x => x.value).indexOf(val);
        return maps[elPos].name;
    }
}
