import { environment } from 'src/environments/environment';

export class Constants {

  //user
  static registerUser = environment.webApi + 'account/register';
  static login = environment.webApi +  'account/login';
  static IsUserNameDuplicated = environment.webApi + 'account/IsValidateUserName';
  static getUserInfo = environment.webApi + 'account/userInfo'
  //flat
  static flat = environment.webApi +  'flat'; 
  static getAllFlats = environment.webApi +  'flat/getAll';
  static deleteFlat = environment.webApi +  'flat';
  static updateFlat = environment.webApi + 'flat';
  //file
  static uploadFileUrl = environment.webApi + 'file';
  static deleteFileUrl = environment.webApi +  'file';
  //search
  static searchFlat = environment.webApi + 'search'
}