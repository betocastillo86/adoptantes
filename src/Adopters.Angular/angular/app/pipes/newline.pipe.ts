import { PipeTransform, Pipe } from "@angular/core";

@Pipe({
    name:'newLine'
})
export class NewLinePipe implements PipeTransform
{
    transform(value: any, ...args: any[]) {
        return value.replace(/\n/g, '<br>');
    }
}