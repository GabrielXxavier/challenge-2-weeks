import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { Book } from 'src/app/models/book.model';
import {FormBuilder, Validator, Validators} from '@angular/forms';
import { Category } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';
import { Observable } from 'rxjs';
import { DropdownModule } from 'primeng/dropdown';


@Component({
  selector: 'app-book-register',
  templateUrl: './book-register.component.html',
  styleUrls: ['./book-register.component.css']
})
export class BookRegisterComponent { 
  
  listCategories: [] | undefined | string | any;
  ngOnInit() {
    this.listCategories = [
      {name: 'Ficção'},
      {name: 'Não-ficção'},
      {name: 'Fantasia'},
      {name: 'Romance'},
      {name: 'Aventura'},
      {name: 'Mistério'},
      {name: 'Ciência'},
      {name: 'História'},
      {name: 'Biografia'}
    ];
  }

  
  constructor(private bookService: BookService, private fb: FormBuilder, private categoryService: CategoryService) {
    this.categories$ = this.categoryService.getCategories();
  }

  categories$: Observable<Category[]>;
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
    //this.bookForm.value.category as Category; 
    //this.bookService.postBook().subscribe(() => {
   ////   this.onCancel();
 //     this.bookService.triggerRefresh();
//})
  }
}