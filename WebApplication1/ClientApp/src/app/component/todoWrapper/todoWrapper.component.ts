import {Component, Input} from "@angular/core";
import { todos } from "src/app/data/todos";
import {ITodoItem} from "../../type/todoType";

@Component({
  selector: "todo",
  templateUrl: "todoWrapper.component.html"
})
export class TodosComponent{
  @Input() todos:ITodoItem[]
}
