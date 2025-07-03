import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { Book } from 'src/app/models/book.model';
import {FormBuilder, Validator, Validators} from '@angular/forms';
import { Category } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';
import { Observable } from 'rxjs';



@Component({
  selector: 'app-book-register',
  templateUrl: './book-register.component.html',
  styleUrls: ['./book-register.component.css']
})
export class BookRegisterComponent { 
  constructor(private bookService: BookService, private fb: FormBuilder, private categoryService: CategoryService) {
    
  }
  
  listCategories: [] | undefined | string | any;
  categories$!: Observable<Category[]> | undefined ;

  ngOnInit() {
    this.categories$ = this.categoryService.getCategories();
    this.categories$.subscribe(cats => console.log('Categorias recebidas:', cats));
  }
  
  

  
  @Output() getShowRegister = new EventEmitter<boolean>();

  bookForm = this.fb.group({
    title: ['' , [Validators.required, Validators.minLength(3)]],
    author: ['' , [Validators.required, Validators.minLength(3)]],
    category: ['', [Validators.required, Validators.minLength(3)]],
    value: [0 , [Validators.required, Validators.min(0.01)]]
  })

  
   

  onCancel(){
    this.getShowRegister.emit(false);
  }

  onSubmit() {
    console.log( 'valor do category form' + this.bookForm.value.category)
    this.bookService.postBook(this.bookForm.value as unknown as Book).subscribe(() => {
    this.onCancel();
     this.bookService.triggerRefresh();
  })
  }
}