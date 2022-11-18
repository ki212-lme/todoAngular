import {Component, Input} from "@angular/core";
import { todos } from "src/app/data/todos";
import {ITodoItem} from "../../type/todoType";

@Component({
  selector: "todo-list",
  templateUrl: "todoList.component.html",
  styleUrls: ['./todoList.component.css']
})
export class TodoListComponent{
  @Input() todos:ITodoItem[]
}
