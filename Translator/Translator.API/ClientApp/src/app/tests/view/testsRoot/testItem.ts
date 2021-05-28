import { Type } from '@angular/core';

export class TestItem {
  constructor(public component: Type<any>, public data: any) {}
}
