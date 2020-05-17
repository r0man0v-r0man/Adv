import { UploadFile } from 'ng-zorro-antd/upload';

export interface FlatRentModel {
    id: number;
    userId: string;
    isActive: boolean;
    images: UploadFile[];
    address: string;
    floor: number;
    allFloor: number;
    rooms: number;
    balcony: number;
    furniture: boolean;
    refrigerator:  boolean;
    microwaveOven:  boolean;
    internet:  boolean;
    washingMachine:  boolean;
    price: number;
    duration: number;
    phone: string;
    description: string;
}