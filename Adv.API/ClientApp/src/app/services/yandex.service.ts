import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class YandexService {
  listOfAdresses: Array<{ displayName: string; value: string }> = [];
  constructor() { }
}
