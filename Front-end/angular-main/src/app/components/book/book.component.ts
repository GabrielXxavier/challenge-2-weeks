import { Component } from '@angular/core';
import { Book } from '../../models/book.model';
import { BookService } from '../../services/book.service';
import { Observable , Subscription} from 'rxjs';


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

    books$: Observable<Book[]>;

    constructor(private bookService: BookService) {
      this.books$ = this.bookService.getBooks();
      this.bookService.refresh$.subscribe(() => {
        this.books$ = this.bookService.getBooks();
      });
    }

    
    getShowEdit(event: boolean) {
        this.showDelete = true;
    }
    getShowDelete(event: boolean) {
        this.showDelete = true;
    }
}
