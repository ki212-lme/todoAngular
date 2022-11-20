import {Component, Input} from "@angular/core";
import {ITodoItem} from "../../type/todoType";
import {TodoService} from "../../apiService/todoService";
import {FormControl, FormGroup, Validator, Validators} from "@angular/forms";

@Component({
  selector: "todo-creator",
  templateUrl: "todoCreator.component.html"
})
export class TodoCreator {
  dateEnable: boolean = true;
  todoForm = new FormGroup({
    description: new FormControl("", Validators.pattern("[A-z]{1,25}")),
    dateComplete: new FormControl(""),
  });

  constructor(private todoService: TodoService) {
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
      this.todoService.createTodo(newTodo).subscribe();
    }
  }
}
