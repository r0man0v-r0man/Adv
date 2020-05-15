import { UploadFile } from 'ng-zorro-antd/upload';

export interface FlatSaleModel {
    userId: string;
    isActive: boolean;
    images: UploadFile[];
    address: string;
    floor: number;
    allFloor: number;
    rooms: number;
    flatArea: number;
    flatLiveArea: number;
    kitchenArea: number;
    balcony: number;
    toilet: number;
    price: number;
    phone: number;
    description: string;
}