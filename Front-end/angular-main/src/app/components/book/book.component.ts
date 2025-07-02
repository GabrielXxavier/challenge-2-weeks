import { Component } from '@angular/core';
import { Book } from '../../models/book.model';
import { BookService } from '../../services/book.service';
import { Observable , Subscription} from 'rxjs';
import { Category } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';


@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css'],
  standalone: false
})
export class BookComponent {
    constructor(private bookService: BookService, private categoryService: CategoryService) {
      this.books$ = this.bookService.getBooks();


      this.bookService.refresh$.subscribe(() => {
        this.books$ = this.bookService.getBooks();
      });
      
    }

    showDelete: boolean = false;
    showEdit: boolean = false;

    bookDeleteSelected?: Book;
    bookEditSelected?: Book ;

    books$: Observable<Book[]>;
    
    
    
    
    getShowEdit(event: boolean) {
        this.showDelete = true;
    }
    getShowDelete(event: boolean) {
        this.showDelete = true;
    }
}
