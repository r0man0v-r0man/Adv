import { PipeTransform, Pipe } from '@angular/core';
import { FlatModel } from '../models/flatModel';

@Pipe({
    name: 'address'
})

export class AddressPipe implements PipeTransform{
    /** transform flat to Address string. Additional: 'full' - to add subHouse */
    transform(flat: FlatModel, type?: string) {
        if(!flat) return null;
        if(flat.street == null || 
            flat.numberOfHouse == null || 
            flat.numberOfHouseCourpus == null ||
            flat.numberOfSubHouse == null ||
            flat.numberOfFlat == null) 
            return null
            
        let result: string = '';
        /** transform to street */
        let street: string = `${flat.street}, `;
        /** transform to house */
        let house: string = `д.${flat.numberOfHouse}`;
        let houseCourpus: string = ' ';
        if(flat.numberOfHouseCourpus !== 0) {
            houseCourpus = `/${flat.numberOfHouseCourpus} `;
        }
        house = house + houseCourpus;

        let flatNumber: string = `кв.${flat.numberOfFlat}`
        /**calculate all address using additional param type*/
        if(type !== 'full'){
            result = street + house + flatNumber;
        }
        else{
            let subHouse: string = ' ';
            if(flat.numberOfSubHouse !== 0){
                subHouse = `подъезд ${flat.numberOfSubHouse} `;
            }
            result = street + house + subHouse + flatNumber;
        }

        return result;
    }

}