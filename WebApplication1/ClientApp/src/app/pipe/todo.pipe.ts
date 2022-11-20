import {Pipe, PipeTransform} from '@angular/core';
import {ITodoItem} from "../type/todoType";
@Pipe ({
  name : 'todoFilter'
})
export class TodoPipe implements PipeTransform {
  transform(arr:ITodoItem[],callback: (item:ITodoItem) => boolean) : ITodoItem[] {
    return arr.filter(x=>callback(x));
  }
}
