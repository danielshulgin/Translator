// tslint:disable: directive-selector
import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[testHost]',
})
export class TestDirective {
  constructor(public viewContainerRef: ViewContainerRef) { }
}
