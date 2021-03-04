import { Component, OnInit } from '@angular/core';
import Word from '../models/Word';
import WordService from '../api/word.service';


@Component({
  selector: 'app-word',
  templateUrl: './word.component.html',
  styleUrls: ['./word.component.css']
})

export class WordComponent implements OnInit {
  words: Array<Word> = [];

  constructor(private wordService: WordService) { }

  ngOnInit() {
    this.wordService.getAll().subscribe(data => {
      this.words = data;
    });
  }

}
