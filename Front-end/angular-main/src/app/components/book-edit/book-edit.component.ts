import { Component, EventEmitter } from '@angular/core';
import { Input , Output} from '@angular/core';
import { Book } from 'src/app/models/book.model';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.css']
})
export class BookEditComponent {
  @Output() getShowEdit = new EventEmitter<boolean>();

  @Input() book?: Book;

  onCancel() {
    this.getShowEdit.emit(false);
  }
  constructor(private bookService: BookService) {
          
    } 
  putBook(){
    if (!this.book || !this.book.title || !this.book.author || !this.book.category || this.book.value <= 0) {
      alert('Por favor, preencha todos os campos corretamente.');
      return;
    }
    this.bookService.putBook(this.book).subscribe(() => {
      this.onCancel();
    });
  }
}
 