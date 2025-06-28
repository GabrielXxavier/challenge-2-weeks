import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { Book } from 'src/app/models/book.model';
import {FormBuilder, Validator, Validators} from '@angular/forms';


@Component({
  selector: 'app-book-register',
  templateUrl: './book-register.component.html',
  styleUrls: ['./book-register.component.css']
})
export class BookRegisterComponent { 
  
  constructor(private bookService: BookService, private fb: FormBuilder) {}

  @Output() getShowRegister = new EventEmitter<boolean>();

  bookForm = this.fb.group({
    title: ['' , [Validators.required, Validators.minLength(3)]],
    author: ['' , [Validators.required, Validators.minLength(3)]],
    category: ['' , [Validators.required, Validators.minLength(3)]],
    value: [0 , [Validators.required, Validators.min(0.01)]]
  })

  
   

  onCancel(){
    this.getShowRegister.emit(false);
  }

  onSubmit() {
    
    this.bookService.postBook(this.bookForm.value as Book).subscribe(() => {
      this.onCancel();
      this.bookService.triggerRefresh();
    })
  }
}