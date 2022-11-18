import {Pipe, PipeTransform} from '@angular/core';
import {ITodoItem} from "../type/todoType";
@Pipe ({
  name : 'todoFilter'
})
export class TodoPipe implements PipeTransform {
  transform(arr:ITodoItem[],filterState:boolean) : ITodoItem[] {
    return arr.filter(x=>x.isCompleted==filterState);
  }
}
