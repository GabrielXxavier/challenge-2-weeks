import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { Book } from 'src/app/models/book.model';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-book-register',
  templateUrl: './book-register.component.html',
  styleUrls: ['./book-register.component.css']
})
export class BookRegisterComponent {
  @Output() getShowRegister = new EventEmitter<boolean>();

  id = '';
  title = '';
  author = '';
  category = '';
  value:number = 0;

 constructor(private bookService: BookService) {

  }

  onCancel(){
    this.getShowRegister.emit(false);
  }

  postBook() {

    const book: Book = {
      id: "b27e822c-c217-4024-879b-71d9c79d71a1",
      title: this.title,
      author: this.author,
      category: this.category,
      value: this.value
    };
    if (!book.title || !book.author || !book.category || book.value <= 0) {
      alert('Por favor, preencha todos os campos corretamente.');
      return;
    }
    this.bookService.postBook(book).subscribe(() => {;
      this.onCancel();
      this.bookService.triggerRefresh();
    })
    
    
  }
}