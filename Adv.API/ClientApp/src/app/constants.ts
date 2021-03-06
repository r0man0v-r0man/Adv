import { environment } from 'src/environments/environment';

export class Constants {

  //user
  static registerUser = environment.webApi + 'account/register';
  static login = environment.webApi +  'account/login';
  static IsUserNameDuplicated = environment.webApi + 'account/IsValidateUserName';
  static getUserInfo = environment.webApi + 'account/userInfo'
  //adverts
  static addFlatRent = environment.webApi + 'advert/addFlatRent';
  static addFlatSale = environment.webApi + 'advert/addFlatSale';
  static addHouseRent = environment.webApi + 'advert/addHouseRent';
  static addHouseSale = environment.webApi + 'advert/addHouseSale';
  static getFlatRent = environment.webApi + 'advert/getFlatRent';
  static getFlatSale = environment.webApi + 'advert/getFlatSale';
  static getHouseSale = environment.webApi + 'advert/getHouseSale';
  static getHouseRent = environment.webApi + 'advert/getHouseRent';
  static getFlatRentsURL = environment.webApi + 'advert/getFlatRents';
  static getFlatSalesURL = environment.webApi + 'advert/getFlatSales';
  static getHouseSalesURL = environment.webApi + 'advert/getHouseSales';
  static getHouseRentsURL = environment.webApi + 'advert/getHouseRents';
  static getAnyFlatRentsURL = environment.webApi + 'advert/getAnyFlatRents';
  static getAnyFlatSalesURL = environment.webApi + 'advert/getAnyFlatSales';
  static getAnyHouseRentsURL = environment.webApi + 'advert/getAnyHouseRents';
  static getAnyHouseSalesURL = environment.webApi + 'advert/getAnyHouseSales';
  static getLastFlatRentURL = environment.webApi + 'advert/getLastFlatRent';
  static getLastFlatSaleURL = environment.webApi + 'advert/getLastFlatSale';
  static getLastHouseRentURL = environment.webApi + 'advert/getLastHouseRent';
  static getLastHouseSaleURL = environment.webApi + 'advert/getLastHouseSale';
  static getUserAdvertsURL = environment.webApi + 'advert/getUserAdverts';
  static deleteFlatSaleURL = environment.webApi + 'advert/deleteFlatSale';
  static deleteFlatRentURL = environment.webApi + 'advert/deleteFlatRent';
  static deleteHouseRentURL = environment.webApi + 'advert/deleteHouseRent';
  static deleteHouseSaleURL = environment.webApi + 'advert/deleteHouseSale';
  static updateAdvertURL = environment.webApi + 'advert/updateAdvert';

  // payment
  static checkoutURL = environment.webApi + 'payment/checkout';

  // locations
  static getLocationsURL = environment.webApi + 'yandexAddress/getLocations';
  //file
  static uploadFileUrl = environment.webApi + 'file';
  static deleteFileUrl = environment.webApi +  'file';
  //search
  static searchFlat = environment.webApi + 'search'
}
