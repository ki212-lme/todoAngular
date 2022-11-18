import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {TodoComponent} from "./component/todo/todo.component";
import {TodoListComponent} from "./component/todoList/todoList.component";
import {TodoCreator} from "./component/todoCreate/todoCreator.component";
import {TodosComponent} from "./component/todoWrapper/todoWrapper.component";

@NgModule({
  declarations: [
    AppComponent,
    TodoComponent,
    TodoListComponent,
    TodoCreator,
    TodosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
