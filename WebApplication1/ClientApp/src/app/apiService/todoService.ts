import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ITodoItem} from "../type/todoType";

@Injectable({
  providedIn: "root"
})
export class TodoService{
  constructor(private httpClient:HttpClient) {
  }
  getAllTodos():Observable<ITodoItem[]>{
    return  this.httpClient.get<ITodoItem[]>("https://localhost:7139/api/todo");
  }
  createTodo(todo:ITodoItem):Observable<ITodoItem>{
    return  this.httpClient.post<ITodoItem>("https://localhost:7139/api/todo",todo);
  }
}
