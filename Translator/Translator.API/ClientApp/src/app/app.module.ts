import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { JwtModule } from "@auth0/angular-jwt";
import { AuthGuard } from './shared/guards/auth.guard';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ErrorHandlerService } from './shared/services/error-handler.service';
import { PrivacyComponent } from './Privacy/Privacy.component';

import {MatFormFieldModule} from '@angular/material/form-field';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import {MatDialogModule} from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormBuilder } from '@angular/forms';
import { SingleChoiceQuestionComponent } from './tests/view/SingleChoiceQuestion/SingleChoiceQuestion.component';
import { TestsRootComponent } from './tests/view/testsRoot/testsRoot.component';
import { TestChieldComponent } from './tests/view/testsRoot/testChield.component';
import { TestDirective } from './tests/view/testsRoot/testDirective';
import { SkillTestsComponent } from './tests/view/skillTests/skillTests.component';
import { SkillTestsResultComponent } from './tests/view/skillTestsResult/skillTestsResult.component';

export function tokenGetter() {
  return localStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    TestDirective,
    FetchDataComponent,
    TestChieldComponent,
    PrivacyComponent,
    TestsRootComponent,
    SingleChoiceQuestionComponent,
    SkillTestsComponent
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'authentication', loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule) },
    { path: 'company', loadChildren: () => import('./company/company.module').then(m => m.CompanyModule), canActivate: [AuthGuard] },
    { path: 'privacy', component: PrivacyComponent, canActivate: [AuthGuard] },
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent },
    { path: 'tests', component: SkillTestsComponent },
    { path: 'tests-result', component: SkillTestsResultComponent }
    ], { relativeLinkResolution: 'legacy' }),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:44385"],
        blacklistedRoutes: []
      }
    }),
    MatFormFieldModule,
    MatToolbarModule,
    MatButtonModule,
    MatDialogModule,
    MatInputModule,
    BrowserAnimationsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
