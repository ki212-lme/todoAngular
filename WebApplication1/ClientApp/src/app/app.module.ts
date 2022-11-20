import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {TodoComponent} from "./component/todo/todo.component";
import {TodoListComponent} from "./component/todoList/todoList.component";
import {TodosComponent} from "./component/todoWrapper/todoWrapper.component";
import {HttpClientModule} from "@angular/common/http";
import {TodoPipe} from "./pipe/todo.pipe";
import {ReactiveFormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    TodoComponent,
    TodoListComponent,
    TodosComponent,
    TodoPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
