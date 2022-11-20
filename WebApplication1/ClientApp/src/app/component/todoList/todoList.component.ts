import {Component, DoCheck, Input, OnInit} from "@angular/core";
import {ITodoItem} from "../../type/todoType";

@Component({
  selector: "todo-list",
  templateUrl: "todoList.component.html",
  styleUrls: ['./todoList.component.css','../todo/todo.component.css']
})
export class TodoListComponent implements DoCheck {
  @Input() todos:ITodoItem[]
  @Input() showArchived:boolean = false;
  renderFlag:boolean = true;
  static filter(item:ITodoItem,state:boolean,acr:boolean):boolean{
    if (item.isCompleted==state && item.isArchived==acr){
      return true;
    }
    return false
  }
  filterByState(item:ITodoItem,comp:boolean,arch:boolean){
    return TodoListComponent.filter(item ,comp,arch);
  }
  getTodos(){
    return this.transform(this.todos,this.filterByState,false, this.showArchived)
  }
  transform(arr: ITodoItem[], callback: (item: ITodoItem, isCompleted: boolean, isArchived: boolean) => boolean, isCompleted: boolean, isArchived: boolean): ITodoItem[] {
    let newCompArr: ITodoItem[] = arr.filter(x => callback(x, isCompleted, isArchived));
    let newUnComArr= arr.filter(x => callback(x, !(isCompleted), isArchived));
    return [...newCompArr, ...newUnComArr];
  }
  ngDoCheck():void{
  }
}
