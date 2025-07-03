import { Component, EventEmitter } from '@angular/core';
import { Input , Output} from '@angular/core';
import { Book } from 'src/app/models/book.model';
import { BookService } from 'src/app/services/book.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Category } from 'src/app/models/category.model';
import { Observable } from 'rxjs';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.css']
})
export class BookEditComponent { 
  
  @Output() getShowEdit = new EventEmitter<boolean>();
  @Input() book?: Book;
  bookEditForm!: FormGroup;
  categories$!: Observable<Category[]> | undefined ;

  constructor(private bookService: BookService, private fb: FormBuilder, private categoryService: CategoryService) {};

  ngOnInit(){
    this.categories$ = this.categoryService.getCategories();
    this.categories$.subscribe(categories => console.log('Categorias recebidas:', categories));
  
    
      console.log(this.book);
      this.bookEditForm = this.fb.group({
        id : [this.book?.id],
        title: [this.book?.title, [Validators.required, Validators.minLength(3)]],
        author: [this.book?.author , [Validators.required, Validators.minLength(3)]],
        category: ["" , [Validators.required, Validators.minLength(3)]],
        value: [this.book?.value , [Validators.required, Validators.min(0.01)]]
      }) 
  };

  onCancel() {
    this.getShowEdit.emit(false);
  };
 
  onSubmit (){
    this.bookService.putBook(this.bookEditForm.value).subscribe(() => {
      this.bookService.triggerRefresh();
      this.onCancel();
    });
  };
}
 