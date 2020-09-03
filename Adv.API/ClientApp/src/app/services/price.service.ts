import { Injectable } from '@angular/core';

@Injectable()
export class PriceService {
  formatterDollar = (value: number) => `$ ${value}`;
  parserDollar = (value: string) => value.replace('$ ', '');
  constructor() { }
}
