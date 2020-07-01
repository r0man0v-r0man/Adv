import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'duration'
})

export class DurationPipe implements PipeTransform{
    /**transform duration enum to duration Name */
    transform(duration: number){
        let result = '';

        if(duration === 0) {
            result = 'Длительная';
        }
        if(duration === 1) {
            result = 'Часы/Сутки';
        }
        return result;
    }
}