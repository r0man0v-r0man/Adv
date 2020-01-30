import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'city'
})

export class CityPipe implements PipeTransform{
    /**transform city enum to City Name */
    transform(cities: number){
        let result = '';

        if(cities === 0) {
            result = 'Несвиж';
        }

        return result;
    }
}