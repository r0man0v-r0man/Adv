import { UploadFile } from 'ng-zorro-antd';

export interface FlatModel{

    rooms: number;
    isActive: boolean;
    price: number;
    duration: number;
    description: string;
    files: UploadFile[];
    id: number;
    city: number;
    street: string;
    numberOfHouse: number;
    numberOfHouseCourpus: number;
    numberOfSubHouse: number;
    numberOfFlat: number;
    created: any;
    userId?: string;
    furniture: boolean;
    refrigerator: boolean;
    microwaveOven: boolean;
    internet:boolean;
    washingMachine:boolean;
    floor: number;
    allFloor?: number; 
    phoneNumberPrefix: string;
    phoneNumber: string;

}