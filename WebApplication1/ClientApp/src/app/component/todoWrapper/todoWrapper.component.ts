import {Component, Input, OnInit} from "@angular/core";
import { todos } from "src/app/data/todos";
import {ITodoItem} from "../../type/todoType";
import {TodoService} from "../../apiService/todoService";

@Component({
  selector: "todo",
  templateUrl: "todoWrapper.component.html"
})
export class TodosComponent implements OnInit{
  todos : ITodoItem[] = []

  constructor(private todoService:TodoService) {}

  ngOnInit(): void {
    this.todoService.getAllTodos().subscribe((data)=>{
      this.todos = data;
    })
  }
}
