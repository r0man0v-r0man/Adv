import { NzUploadFile } from 'ng-zorro-antd/upload/interface';
import {Address} from './address.interface';

export interface HouseSaleModel {
    id: number;
    userId: string;
    isActive: boolean;
    images: NzUploadFile[];
    address: Address;
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
    phone: string;
    description: string;
    created: Date;
    lastModified: Date;
}
