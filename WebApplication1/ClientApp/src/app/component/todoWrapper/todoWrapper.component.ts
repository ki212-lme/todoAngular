import {Component, DoCheck, Input, OnChanges, OnInit, SimpleChanges} from "@angular/core";
import {ITodoItem} from "../../type/todoType";
import {TodoService} from "../../apiService/todoService";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: "todo",
  templateUrl: "todoWrapper.component.html",
  styleUrls: ['todoWrapper.component.css','../../app.component.css']
})
export class TodosComponent implements OnInit {
  todos: ITodoItem[] = []
  dateEnable: boolean = true;
  showArchived: boolean = false;

  todoForm = new FormGroup({
    description: new FormControl("", Validators.pattern("[A-z]{1,25}")),
    dateComplete: new FormControl(""),
  });

  constructor(private todoService: TodoService) {
  }

  ngOnInit(): void {
    this.todoService.getAllTodos().subscribe((data) => {
      this.todos = data;
    })
  }

  addTodo() {
    if (this.todoForm.status == "VALID" && this.todoForm.controls.description.value != "") {
      const newTodo: ITodoItem = {
        dateComplete: this.dateEnable && this.todoForm.controls.dateComplete.value != "" ?
          new Date(`${this.todoForm.controls.dateComplete.value}`) : null,
        description: `${this.todoForm.controls.description.value}`,
        id: 0,
        isCompleted: false,
        isArchived: false
      };
      this.todoService.createTodo(newTodo).subscribe(data => {
        if (data) {
          this.ngOnInit();
        }
      });
    }
  }

}

