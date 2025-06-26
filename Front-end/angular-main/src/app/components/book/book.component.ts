import { Component } from '@angular/core';
import { Book } from '../../models/book.model';
import { BookService } from '../../services/book.service';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css'],
  standalone: false
})
export class BookComponent {
    showDelete: boolean = false;
    showEdit: boolean = false;

    bookDeleteSelected?: Book;
    bookEditSelected: Book | undefined;

    books$ = new Observable<Book[]>();

    
    constructor(private bookService: BookService) {
      this.getBooks();
    }

    getBooks() {
      this.books$ = this.bookService.getBooks();
      
    }

    
    getShowEdit(event: boolean) {
        this.showDelete = true;
    }
    getShowDelete(event: boolean) {
        this.showDelete = true;
    }
}
