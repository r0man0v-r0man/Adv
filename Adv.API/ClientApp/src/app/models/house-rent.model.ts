import { UploadFile } from 'ng-zorro-antd/upload';

export interface HouseRentModel {
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
}