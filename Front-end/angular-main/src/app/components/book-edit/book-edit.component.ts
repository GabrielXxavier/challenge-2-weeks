import { Component, EventEmitter } from '@angular/core';
import { Input , Output} from '@angular/core';
import { Book } from 'src/app/models/book.model';
import { BookService } from 'src/app/services/book.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.css']
})
export class BookEditComponent { 
  constructor(private bookService: BookService, private fb: FormBuilder) {
    console.log(this.book);
  };

  @Output() getShowEdit = new EventEmitter<boolean>();
  @Input() book?: Book;
  bookEditForm!: FormGroup;

  ngOnInit(){
    if(this.book) {
      console.log(this.book);
      this.bookEditForm = this.fb.group({
        id : [this.book?.id],
        title: [this.book?.title, [Validators.required, Validators.minLength(3)]],
        author: [this.book?.author , [Validators.required, Validators.minLength(3)]],
        category: [this.book?.category , [Validators.required, Validators.minLength(3)]],
        value: [this.book?.value , [Validators.required, Validators.min(0.01)]]
    }) 
    }
  }

  onCancel() {
    this.getShowEdit.emit(false);
  }
 
  onSubmit (){
    this.bookService.putBook(this.bookEditForm.value).subscribe(() => {
      this.bookService.triggerRefresh();
      this.onCancel();
    });
  }
}
 