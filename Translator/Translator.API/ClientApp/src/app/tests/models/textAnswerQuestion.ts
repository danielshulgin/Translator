import { TestNode } from "./testNode";

export class TextAnswerQuestion implements TestNode {
  public Children: TestNode[];
  readonly QuestionText: string;
  public Answer: string;
  public UserAnswer: string;
  public $type: string;

  constructor() { }
}
