import { Duration } from './duration';
import { AdvertType } from './advertType';
import { City } from './city.model';

/** опции фильтрации для страницы квартиры */
export interface FlatFilterOptions extends FilterOptions{
    duration?: Duration;
    advertType: AdvertType;
}
/** опции фильтрации для страницы дома */
export interface HouseFilterOptions{
    duration?: Duration;
    advertType: AdvertType;
}
export interface FilterOptions{
    /** номер страницы */
    city: City;
}