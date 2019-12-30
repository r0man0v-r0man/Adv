import { UploadFile } from 'ng-zorro-antd';

export class FlatModel{

    rooms: number = 1;
    isActive: boolean = true;
    price: number;
    description: string;
    file: UploadFile
    id: number;
    district: number;
    street: string;
    numberOfHouse: number;
    numberOfHouseCourpus: number;
    numberOfSubHouse: number;
    numberOfFlat: number;


    public constructor(init?: Partial<FlatModel>){
        Object.assign(this, init);
    }
    
}