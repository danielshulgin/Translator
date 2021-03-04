import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import Word from '../models/Word';


@Injectable(
)
export default class WordService {
  public API = 'https:/localhost:44335';
  public WORDS_API = `${this.API}/api/word`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Array<Word>> {
    this.http
      .get(this.WORDS_API)
      .subscribe(
        data => console.log('success', data),
        error => console.log('oops', error)
      );

    return this.http.get<Array<Word>>(this.WORDS_API);
  }
}
