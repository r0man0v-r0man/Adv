import { UploadFile } from 'ng-zorro-antd/upload/interface';

export interface HouseSaleModel{
    id: number;
    userId: string;
    isActive: boolean;
    images: UploadFile[];
    address: string;
    houseArea: number;
    houseLiveArea: number;
    kitchenArea: number;
    /** площадь участка */
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
    created: Date;
    lastModified: Date;
}