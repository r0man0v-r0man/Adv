import { UploadFile } from 'ng-zorro-antd/upload/interface';

export interface HouseSaleModel{
    userId: string;
    isActive: boolean;
    images: UploadFile[];
    address: string;
    houseArea: number;
    houseLiveArea: number;
    kitchenArea: number;
    housePlotArea: number;
    heating: boolean;
    water: boolean;
    gas: boolean;
    sewage: boolean;
    electricity: boolean;
    bathhouse: boolean;
    garage: boolean;
    price: number;
    phone: number;
    description: string;
}