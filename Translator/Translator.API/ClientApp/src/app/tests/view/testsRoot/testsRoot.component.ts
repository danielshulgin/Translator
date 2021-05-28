import { Component, Input, OnInit } from '@angular/core';
import { SingleChoiceQuestions } from '../../models/singleChoiceQuestions';
import { TestNode } from '../../models/testNode';
import { TextAnswerQuestion } from '../../models/textAnswerQuestion';
import { SingleChoiceQuestionComponent } from '../SingleChoiceQuestion/SingleChoiceQuestion.component';
import { TextAnswerQuestionComponent } from '../textAnswerQuestion/textAnswerQuestion.component';
import { TestComponent } from './test.component';
import { TestItem } from './testItem';

@Component({
  selector: 'app-testsRoot',
  templateUrl: './testsRoot.component.html',
  styleUrls: ['./testsRoot.component.scss']
})
export class TestsRootComponent implements OnInit, TestComponent {

  @Input() rootNode: TestNode;
  @Input() data: any;
  testItems: TestItem[] = [];

  constructor() { }

  ngOnInit() {
    if(this.rootNode == undefined){
      this.rootNode = this.data;
    }
    if(this.rootNode == undefined){

      return;
    }
    console.log(JSON.stringify(this.rootNode));
    for(let i = 0; i < this.rootNode.Children.length; i++){
      let chieldNode = this.rootNode.Children[i];
      if(chieldNode.$type == 'Translator.Domain.Models.SkillTests.SingleChoiseQuestion, Translator.Domain'){
        this.testItems[i] = new TestItem(SingleChoiceQuestionComponent, <SingleChoiceQuestions> chieldNode);
      }
      else if(chieldNode.$type == 'Translator.Domain.Models.SkillTests.GroupTestNode, Translator.Domain'){
        this.testItems[i] = new TestItem(TestsRootComponent, <TestNode>chieldNode);
      }
      else if(chieldNode.$type == 'Translator.Domain.Models.SkillTests.TextAnswerQuestion, Translator.Domain'){
        this.testItems[i] = new TestItem(TextAnswerQuestionComponent,<TextAnswerQuestion> chieldNode);
      }
      console.log(chieldNode.$type);
    }
  }
}
