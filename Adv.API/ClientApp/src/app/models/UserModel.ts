import { FlatModel } from './flatModel';

export class UserModel{
    id: string;
    userName: string;
    password: string;
    flatsViewModels: FlatModel[];
}