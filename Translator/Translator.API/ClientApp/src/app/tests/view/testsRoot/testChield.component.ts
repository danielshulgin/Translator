import {
  Component,
  Input,
  OnInit,
  ViewChild,
  ComponentFactoryResolver,
} from '@angular/core';

import { TestComponent } from './test.component';
import { TestDirective } from './testDirective';
import { TestItem } from './testItem';

@Component({
  selector: 'app-test-chield',
  template: `
    <div class="app-test-chield-example">
      <ng-template testHost></ng-template>
    </div>
  `
})
export class TestChieldComponent implements OnInit {
  @Input() testItem!: TestItem;
  @ViewChild(TestDirective, { static: true }) testHost!: TestDirective;

  constructor(private componentFactoryResolver: ComponentFactoryResolver) {}
  ngOnInit(): void {
    this.loadComponent();
  }

  ngAfterViewInit () {

  }

  loadComponent() {
    const testItem = this.testItem;

    const componentFactory = this.componentFactoryResolver.resolveComponentFactory(
      testItem.component
    );

    const viewContainerRef = this.testHost.viewContainerRef;
    viewContainerRef.clear();

    const componentRef = viewContainerRef.createComponent<TestComponent>(
      componentFactory
    );
    componentRef.instance.data = testItem.data;
  }
}
