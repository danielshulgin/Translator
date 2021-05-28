import { Component, OnInit } from '@angular/core';

import { AdService } from './ad.service';
import { AdItem } from './ad-item';

@Component({
  selector: 'app-root',
  template: `
    <div *ngFor="let item of ads">
      <app-ad-banner [ads]="item"></app-ad-banner>
    </div>
  `
})
export class AppComponent implements OnInit {
  ads: AdItem[] = [];
  interval: any;
  constructor(private adService: AdService) {}

  ngOnInit() {
    this.ads = this.adService.getAds();
    this.showContent();
  }

  showContent() {
    this.interval = setInterval(() => {
      console.log(this.ads[2].data.i);
    }, 1000);
  }
}
