import { NzUploadFile } from 'ng-zorro-antd/upload';
import {GeoObject} from './yandex';

export interface FlatRentModel {
    id: number;
    userId: string;
    isActive: boolean;
    images: NzUploadFile[];
    address: GeoObject;
    floor: number;
    allFloor: number;
    rooms: number;
    balcony: number;
    furniture: boolean;
    refrigerator: boolean;
    microwaveOven: boolean;
    internet: boolean;
    washingMachine: boolean;
    price: number;
    duration: number;
    phone: string;
    description: string;
    created: Date;
    lastModified: Date;
}
