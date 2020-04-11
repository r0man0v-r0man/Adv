import { UploadFile } from 'ng-zorro-antd';

export interface FlatSaleModel {
    // кол-во комнат
    rooms: number;
    // активное объявление или нет
    isActive: boolean;
    // цена 
    price: number;
    // описание объявления
    description: string;
    // картинки к объявлению
    files: UploadFile[];
    // уникальный номер объявления
    id: number;
    // город 
    city: number;
    // улица
    street: string;
    // номер дома
    numberOfHouse: number;
    // корпус дома
    numberOfHouseCourpus: number;
    // номер подъеза
    numberOfSubHouse: number;
    // номер квартиры
    numberOfFlat: number;
    // дата создания объявления
    created: any;
    // уникальный идентификатор пользователя (token JWT)
    userId?: string;
    // этаж
    floor: number;
    // всего этажей в доме
    allFloor?: number; 
    // префикс номера, например: +375
    phoneNumberPrefix: string;
    // номер телефона
    phoneNumber: string;
}