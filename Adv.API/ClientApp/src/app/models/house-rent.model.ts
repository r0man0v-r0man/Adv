import { UploadFile } from 'ng-zorro-antd/upload';
import { City } from './city.model';

export interface HouseRentModel {
    id: number;
    userId: string;
    isActive: boolean;
    images: UploadFile[];
    address: string;
    rooms: number;
    furniture: boolean;
    refrigerator:  boolean;
    microwaveOven:  boolean;
    internet:  boolean;
    washingMachine:  boolean;
    bathhouse:  boolean;
    garage: boolean;
    price: number;
    duration: number;
    phone: string;
    description: string;
    created: Date;
    lastModified: Date;
    city: City;
}