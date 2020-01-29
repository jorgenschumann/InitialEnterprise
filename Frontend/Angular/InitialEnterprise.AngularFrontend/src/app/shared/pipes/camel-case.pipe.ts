import { Pipe, PipeTransform, Injectable } from '@angular/core';
import { stringify } from 'querystring';

@Injectable({
  providedIn: 'root'
})

@Pipe({
  name: 'camel-case'
})
export class CamelCasePipe implements PipeTransform {

  transform(value: string, args?: any): any {
    if (value) {
      return value.charAt(0).toLowerCase() + value.slice(1);
    }
    return value;
  }

}
