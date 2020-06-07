import { Duration } from './duration';
import { AdvertType } from './advertType';

/** опции фильтрации для страницы квартиры */
export interface FlatFilterOptions{
    duration?: Duration;
    advertType: AdvertType;
}
/** опции фильтрации для страницы дома */
export interface HouseFilterOptions{
    duration?: Duration;
    advertType: AdvertType;
}