import { Component, OnInit } from '@angular/core';
import { SkillTestService } from 'src/app/shared/services/skill-test.service.service';
import { TestNode } from '../../models/testNode';
import { Router } from '@angular/router';

@Component({
  selector: 'app-skillTests',
  templateUrl: './skillTests.component.html',
  styleUrls: ['./skillTests.component.scss']
})
export class SkillTestsComponent implements OnInit {
  public isDataAvailable:boolean = false;
  public testRootNode: TestNode;

  constructor(private _skillTestService: SkillTestService, private _router: Router) {
      this._skillTestService.getTest( "api/skilltests/test").subscribe(
        (testNode) => {
          console.log(testNode);
          this.testRootNode = testNode;
          this.isDataAvailable = true;

        });
   }
  ngOnInit() {
  }
  submitTest() {

    this._skillTestService.getTestPoints( "api/skilltests/CheckTest", JSON.stringify(this.testRootNode)).subscribe(
      (checkTestResponse) => {
        this._skillTestService.checkTest = checkTestResponse;
        this._router.navigate(["/tests-result"]);
        console.log(checkTestResponse.earnedPoints);
      });
  }
}
