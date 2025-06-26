import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Book } from "../models/book.model";
import { environment } from "src/environments/environment.development";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class BookService {

    books$ = new Observable<Book[]>();

    private apiUrl = environment.bookApiUrl;
    constructor(private httpClient: HttpClient) {
        this.httpClient = httpClient;
    }

    getBooks(){
        return this.httpClient.get<Book[]>(this.apiUrl, );
    }

    postBook(book: Book) {
        return this.httpClient.post<Book>(this.apiUrl, book)
    }

    deleteBook(id: string | undefined) {
        return this.httpClient.delete(`${this.apiUrl}?id=${id}`);
    }
    putBook(book: Book | undefined) {
        return this.httpClient.put<Book>(this.apiUrl, book);
    }
}