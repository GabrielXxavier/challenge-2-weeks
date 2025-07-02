// utilizei signal no bookCount pois ele salva o ultimo valor
import { Injectable, signal } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Book } from "../models/book.model";
import { environment } from "src/environments/environment.development";
import { Observable, Subject, tap} from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class BookService {

    constructor(private httpClient: HttpClient) {
        this.httpClient = httpClient;
    }

    refreshSubject = new Subject<void>();
    

    get refresh$(): Observable<void> {
        return this.refreshSubject.asObservable();
    }


    private apiUrl = environment.bookApiUrl + '/Books';
    triggerRefresh() {
        this.refreshSubject.next();
    }
    
    getBooks(){
        return this.httpClient.get<Book[]>(this.apiUrl).pipe(tap(books => {
            this.sortedBooks(books);}));
    }

    postBook(book: Book) {
        return this.httpClient.post<Book>(this.apiUrl, book)
    }

    deleteBook(id: string | undefined) {
        return this.httpClient.delete(`${this.apiUrl}?id=${id}`);
    }
    putBook(book: Book) {
        return this.httpClient.put<Book>(this.apiUrl, book);
    }

    sortedBooks(Books: Book[]): Book[] {
        return Books.sort((a, b) => {
            return a.title.localeCompare(b.title);
        });
    }
}