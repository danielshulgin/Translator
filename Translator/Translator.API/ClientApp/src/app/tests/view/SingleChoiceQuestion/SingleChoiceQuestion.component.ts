import { Component, OnInit } from '@angular/core';
import { TestComponent } from '../testsRoot/test.component';

@Component({
  selector: 'app-SingleChoiceQuestion',
  templateUrl: './SingleChoiceQuestion.component.html',
  styleUrls: ['./SingleChoiceQuestion.component.scss']
})
export class SingleChoiceQuestionComponent implements OnInit, TestComponent {

  isChecked;
  isCheckedName;
  data: any;

  constructor() { }

  ngOnInit() { }

  onChange(e){
    this.isChecked = !this.isChecked;
    this.isCheckedName = e.target.name;
    this.data.UserAnswer = this.data.Answers.indexOf(e.target.name);
  }
}
