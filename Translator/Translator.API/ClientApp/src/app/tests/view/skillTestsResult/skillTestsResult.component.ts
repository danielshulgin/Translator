import { Component, OnInit } from '@angular/core';
import { SkillTestService } from 'src/app/shared/services/skill-test.service.service';
import { CheckTest } from '../../models/checkTestResponse';
import { TestNode } from '../../models/testNode';

@Component({
  selector: 'app-skillTestsResult',
  templateUrl: './skillTestsResult.component.html',
  styleUrls: ['./skillTestsResult.component.scss']
})
export class SkillTestsResultComponent implements OnInit {
  testResult : CheckTest;

  constructor(private _skillTestService: SkillTestService) {

 }

  ngOnInit() {
    this.testResult = this._skillTestService.checkTest;
  }

}
