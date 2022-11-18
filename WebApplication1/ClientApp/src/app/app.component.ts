import { Component } from '@angular/core';
import {ITodoItem} from "./type/todoType";
import {todos} from "./data/todos";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ClientApp'

}
