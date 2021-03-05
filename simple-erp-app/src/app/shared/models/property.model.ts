export class PropertyModel {
    public Name: string;
    public DisplayName: string;
    public IsEditable: boolean;
    constructor() {
        this.DisplayName = this.Name;
        this.IsEditable = false;
    }
}