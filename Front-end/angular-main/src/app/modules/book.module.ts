import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BookEditComponent } from '../components/book-edit/book-edit.component';
import { BookComponent } from '../components/book/book.component';
import { ButtonBookRegisterComponent } from '../components/button-book-register/button-book-register.component';
import { BookDeleteComponent } from '../components/book-delete/book-delete.component';
import { BookRegisterComponent } from '../components/book-register/book-register.component';

import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';



@NgModule({
  declarations: [
    BookComponent,
    BookEditComponent,
    ButtonBookRegisterComponent,
    BookRegisterComponent,
    BookDeleteComponent
  ],
  imports: [
    CommonModule,
    DropdownModule,
    FormsModule,
    ReactiveFormsModule,
    InputTextModule,
    ButtonModule
  ],
  exports: [
    BookComponent,
    BookEditComponent,
    ButtonBookRegisterComponent,
    BookRegisterComponent,
    BookDeleteComponent
  ]
})
export class BookModules { }
