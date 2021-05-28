import { Component, Input, OnInit } from '@angular/core';
import { TestComponent } from '../testsRoot/test.component';

@Component({
  selector: 'app-textAnswerQuestion',
  templateUrl: './textAnswerQuestion.component.html',
  styleUrls: ['./textAnswerQuestion.component.scss']
})
export class TextAnswerQuestionComponent implements OnInit, TestComponent {
  @Input() data: any;
  userAnswer: string;

  constructor() { }

  ngOnInit() {
  }
  public onEndType(e){
    console.log("asd " + e.target.value);
    this.data.UserAnswer = e.target.value;
  }
}
