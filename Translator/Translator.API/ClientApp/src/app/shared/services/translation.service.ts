import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class TranslationService {

constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }
  public getTranslation = (route: string, word: string) : Observable<TranslationDto> => {
    return this._http.get<TranslationDto>(this.createCompleteRoute(route, this._envUrl.urlAddress),
     { params: {
        word: word
      }})
  }


  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}

export interface TranslationDto{

    native:string;

    translations:string[];

    nounsTranslations:string[];

    adjectivesTranslations:string[];

    verbsTranslations:string[];

    collocations:string[];

    sentences:string[];
}
