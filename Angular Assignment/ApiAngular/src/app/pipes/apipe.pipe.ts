import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'apipe'
})
export class ApipePipe implements PipeTransform {

  transform(num: number): string {
    return 'my salary is' + num;
  }

}
