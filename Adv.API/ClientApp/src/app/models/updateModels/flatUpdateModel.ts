export class FlatUpdateModel{
    id: number;
    description: string;
    price: number;
    phoneNumberPrefix: string;
    phoneNumber: string;
    
    public constructor(init?: Partial<FlatUpdateModel>){
        Object.assign(this, init);

    }
}