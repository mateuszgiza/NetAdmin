
import {IssueType} from "../enums";
import {IEnumTypes, EnumExt} from "../../helpers/enum-ext";

export interface IIssue {
    title: string;
    text: string;
    issueType: IssueType;
    issueTypes: IEnumTypes[];
}

export class Issue implements IIssue {
    title: string;
    text: string;
    issueType: IssueType;
    issueTypes: IEnumTypes[];

    constructor() {
        this.issueTypes = EnumExt.getNamesAndValues(IssueType);
    }
}