import {Component, Input} from "@angular/core";
import {ITodoItem} from "../../type/todoType";

@Component({
  selector: "todo-item",
  templateUrl: "todo.component.html"
})
export class TodoComponent{
  @Input() todo: ITodoItem
}
