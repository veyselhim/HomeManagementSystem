import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'statusToYesNo'
})
export class StatusToYesNoPipe implements PipeTransform {

  transform(value: any, ...args: any[]): unknown {
    return value ? "Ödendi" : "Ödenmedi";
  }

}
