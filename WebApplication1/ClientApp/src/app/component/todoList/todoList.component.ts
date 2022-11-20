import {Component, Input} from "@angular/core";
import {ITodoItem} from "../../type/todoType";
import {TodoCreator} from "../todoCreate/todoCreator.component";

@Component({
  selector: "todo-list",
  templateUrl: "todoList.component.html",
  styleUrls: ['./todoList.component.css']
})
export class TodoListComponent{
  @Input() todos:ITodoItem[]
  static filter(item:ITodoItem,state:boolean,acr:boolean):boolean{
    console.log(item);
    if (item.isCompleted==state && item.isArchived==acr){
      return true;
    }
    return false
  }
  filterByState(item:ITodoItem){
    return TodoListComponent.filter(item, true, false);
  }
  filterByAnotherState(item:ITodoItem){
    return TodoListComponent.filter(item, false , false);
  }
}
