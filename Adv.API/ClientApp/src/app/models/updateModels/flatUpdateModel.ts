export class FlatUpdateModel{
    id: number;
    description: string;
    public constructor(init?: Partial<FlatUpdateModel>){
        Object.assign(this, init);
    }
}