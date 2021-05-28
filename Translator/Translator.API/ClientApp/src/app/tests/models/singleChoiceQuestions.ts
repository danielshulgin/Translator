import { TestNode } from "./testNode";

export class SingleChoiceQuestions implements TestNode {
  public Children: TestNode[];
  public QuestionText: string;
  public Answers: string;
  public UserAnswer: number;
  public RightAnswerIndex: number;
  public $type: string;

  constructor() { }
}
