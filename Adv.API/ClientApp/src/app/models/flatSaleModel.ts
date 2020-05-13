import { UploadFile } from 'ng-zorro-antd/upload';

export interface FlatSaleModel {
    userId: string;
    isActive: boolean;
    images: UploadFile[];

}