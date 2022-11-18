import {Component, Input} from "@angular/core";
import { todos } from "src/app/data/todos";
import {ITodoItem} from "../../type/todoType";

@Component({
  selector: "todo-creator",
  templateUrl: "todoCreator.component.html"
})
export class TodoCreator{}
