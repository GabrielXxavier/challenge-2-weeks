import { Component, Input, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Book } from 'src/app/models/book.model';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-book-delete',
  standalone: true,
  templateUrl: './book-delete.component.html',
  styleUrls: ['./book-delete.component.css']
})
export class BookDeleteComponent {
  @Output() getShowDelete = new EventEmitter<boolean>();
  @Input() book? : Book ;
 

  constructor(private bookService: BookService) {
        
  } 

  DeleteBook() {
    
    this.bookService.deleteBook(this.book?.id).subscribe(() => {
      this.onCancel()
    });
      
  }
  
  onCancel(){
    this.getShowDelete.emit(false);
  }
}
