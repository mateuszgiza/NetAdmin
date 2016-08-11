import { EnumExt } from "./enum-ext";

export class IssueTypeFormatValueConverter {
    toView(value) {
        return EnumExt.getName(value);
    }
}

export class TimeElapsedSinceNowValueConverter {
    toView(value: string) {
        let lValue = new Date(value);
        let now: number = new Date().getTime();
        let diff = Math.round((now - lValue.getTime()) / 1000);

        let time: number;
        let unit: string;

        if (diff < 60) {
            time = diff; unit = "seconds";
        }
        else if (diff < 3600) {
            time = Math.round(diff / 60); unit = "minutes";
        }
        else if (diff < 3600 * 24) {
            time = Math.round(diff / 3600); unit = "hours";
        }
        else {
            time = Math.round(diff / (3600 * 24)); unit = "days";
        }

        return `${time} ${unit} ago`;
    }
}
