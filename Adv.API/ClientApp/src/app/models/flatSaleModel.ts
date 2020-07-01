import { NzUploadFile } from 'ng-zorro-antd/upload';
import {Address} from './address.interface';

export interface FlatSaleModel {
    id: number;
    userId: string;
    isActive: boolean;
    images: NzUploadFile[];
    address: Address;
    floor: number;
    allFloor: number;
    rooms: number;
    flatArea: number;
    flatLiveArea: number;
    kitchenArea: number;
    balcony: number;
    toilet: number;
    price: number;
    phone: string;
    description: string;
    created: Date;
    lastModified: Date;
}
