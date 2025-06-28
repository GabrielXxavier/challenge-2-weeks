import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookComponent } from './components/book/book.component';
import { BookDeleteComponent } from './components/book-delete/book-delete.component';
import { BookEditComponent } from './components/book-edit/book-edit.component';
import { ButtonBookRegisterComponent } from './components/button-book-register/button-book-register.component';
import { BookRegisterComponent } from './components/book-register/book-register.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    BookComponent,
    BookEditComponent,
    ButtonBookRegisterComponent,
    BookRegisterComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BookDeleteComponent,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
