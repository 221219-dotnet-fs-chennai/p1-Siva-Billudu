import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'epipe'
})
export class EpipePipe implements PipeTransform {

  transform(num: number): string {
    return 'my salary is '+num;

    
  }

}
