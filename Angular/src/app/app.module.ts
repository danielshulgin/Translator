import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';

import { AppComponent } from './app.component';
import { WordComponent } from '../app/shared/word/word.component';
import WordService from '../app/shared/api/word.service';

const appRoutes: Routes = [
  {
    path: '',
    redirectTo: '/words',
    pathMatch: 'full'
  },
  {
    path: 'words',
    component: WordComponent
  },
];

@NgModule({
  declarations: [
    AppComponent,
    WordComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatListModule,
    MatToolbarModule,
    BrowserAnimationsModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    OwlDateTimeModule,
    OwlNativeDateTimeModule
  ],
  providers: [WordService],
  bootstrap: [AppComponent]
})
export class AppModule {}
