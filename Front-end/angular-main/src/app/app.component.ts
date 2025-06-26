import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BookService } from './services/book.service';
import { Book } from './models/book.model';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: false
})
export class AppComponent {
  title = 'angular-main';
  books: Book[] = [];

  constructor(private bookService: BookService) {
    console.log(this.getBooks())
  }

  getBooks() {
    this.bookService.getBooks()
    .subscribe(books => this.books = books);
  }
}
