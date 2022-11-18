import {Component, Input} from "@angular/core";
import {ITodoItem} from "../../type/todoType";

@Component({
  selector: "todo-item",
  templateUrl: "todo.component.html",
  styleUrls: ['./todo.component.css']
})
export class TodoComponent{
  @Input() todo: ITodoItem
}
