import { FlatRentModel } from './flatRentModel';

export class UserModel{
    id: string;
    userName: string;
    password: string;
    flatRentViewModels: FlatRentModel[];
}