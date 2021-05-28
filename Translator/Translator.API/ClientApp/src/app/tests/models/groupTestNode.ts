import { TestNode } from "./testNode";

export class TestNodeRoot implements TestNode {
  Children: TestNode[];
  public $type: string;
}
