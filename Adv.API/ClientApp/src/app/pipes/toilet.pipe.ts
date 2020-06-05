import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'toilet'
})

export class ToiletPipe implements PipeTransform{
    /** перевод в строку */
    transform(value: number) {
        let result: string = '';
        value === 0 ? result = 'Раздельный' : result = 'Совмещенный';
        
        return result;
    }

}