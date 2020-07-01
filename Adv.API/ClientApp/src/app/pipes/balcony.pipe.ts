import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'balcony'
})

export class BalconyPipe implements PipeTransform{
    /** перевод в строку */
    transform(value: number) {
        let result: string = '';
        value === 0 ? result = 'нет' : result = 'есть';
        
        return result;
    }

}