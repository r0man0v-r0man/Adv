"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const environment_1 = require("src/environments/environment");
class Constants {
}
exports.Constants = Constants;
//user
Constants.registerUser = environment_1.environment.webApi + 'account/register';
Constants.login = environment_1.environment.webApi + 'account/login';
Constants.IsUserNameDuplicated = environment_1.environment.webApi + 'account/IsValidateUserName';
Constants.getUserInfo = environment_1.environment.webApi + 'account/userInfo';
//flat
Constants.flat = environment_1.environment.webApi + 'flat';
Constants.getAllFlats = environment_1.environment.webApi + 'flat/getAll';
Constants.deleteFlat = environment_1.environment.webApi + 'flat';
Constants.updateFlat = environment_1.environment.webApi + 'flat';
//file
Constants.uploadFileUrl = environment_1.environment.webApi + 'file';
Constants.deleteFileUrl = environment_1.environment.webApi + 'file';
//search
Constants.searchFlat = environment_1.environment.webApi + 'search';
//# sourceMappingURL=constants.js.map