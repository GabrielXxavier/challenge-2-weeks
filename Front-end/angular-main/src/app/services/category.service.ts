import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment.development";
import { Category } from "../models/category.model";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpClient: HttpClient) { 
    this.httpClient = httpClient;

  }
  private apiUrl = environment.bookApiUrl + '/Categories';

    getCategories() {
        return this.httpClient.get<Category[]>(this.apiUrl);
    }
}

