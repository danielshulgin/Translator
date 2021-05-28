import { Component, Input } from '@angular/core';

import { AdComponent } from './ad.component';

@Component({
  template: `
    <div class="job-ad">
      <h4>{{ data.headline }}</h4>

      {{ data.body }}
    </div>
  `
})
export class HeroJobAdComponent implements AdComponent {
  interval: any;

  @Input() data: any;
  ngOnInit() {
    this.showContent();
  }

  showContent() {
    this.interval = setInterval(() => {
      this.data.i = 7;
    }, 1000);
  }
}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/
