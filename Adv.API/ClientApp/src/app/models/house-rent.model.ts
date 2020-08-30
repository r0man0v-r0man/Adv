import { NzUploadFile } from 'ng-zorro-antd/upload';

export interface HouseRentModel {
    id: number;
    userId: string;
    isActive: boolean;
    images: NzUploadFile[];
    address: any;
    rooms: number;
    furniture: boolean;
    refrigerator: boolean;
    microwaveOven: boolean;
    internet: boolean;
    washingMachine: boolean;
    bathhouse: boolean;
    garage: boolean;
    price: number;
    duration: number;
    phone: string;
    description: string;
    created: Date;
    lastModified: Date;
}
