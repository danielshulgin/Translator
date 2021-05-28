import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CheckTest } from 'src/app/tests/models/checkTestResponse';
import { TestNodeRoot } from 'src/app/tests/models/groupTestNode';
import { TestNode } from 'src/app/tests/models/testNode';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class SkillTestService {
public checkTest: CheckTest;
constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }
  public getTest = (route: string) : Observable<TestNodeRoot> => {
    return this._http.get<TestNodeRoot>(this.createCompleteRoute(route, this._envUrl.urlAddress))
  }

  public getTestPoints = (route: string, treeRoot: string) : Observable<CheckTest> => {
    return this._http.post<CheckTest>(this.createCompleteRoute(route, this._envUrl.urlAddress),treeRoot, {headers : new HttpHeaders({ 'Content-Type': 'application/json' })})
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}
