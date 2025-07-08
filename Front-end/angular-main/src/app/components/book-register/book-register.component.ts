import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { Book } from 'src/app/models/book.model';
import {FormBuilder,  Validators} from '@angular/forms';
import { Category } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';
import { Observable } from 'rxjs';
import { MessageService } from 'primeng/api';



@Component({
  selector: 'app-book-register',
  templateUrl: './book-register.component.html',
  styleUrls: ['./book-register.component.css']
})
export class BookRegisterComponent {
  @Output() getShowRegister = new EventEmitter<boolean>();

  categories$!: Observable<Category[]> | undefined ;
 
  constructor(private bookService: BookService, private fb: FormBuilder, private categoryService: CategoryService, private messageService: MessageService){}
  
  ngOnInit() {
    this.categories$ = this.categoryService.getCategories();
    this.categories$.subscribe(categories => console.log('Categorias recebidas:', categories));
  }
  
  bookForm = this.fb.group({
    title: ['' , [Validators.required, Validators.minLength(3), Validators.maxLength(80)]],
    author: ['' , [Validators.required, Validators.minLength(3)]],
    category: ['', [Validators.required, Validators.minLength(3)]],
    value: [0.00 , [Validators.required, Validators.pattern('^[0-9]*$') , Validators.min(0.01)]]

  })

  showToast(severity: string,  summary: string, detail: string){
    this.messageService.add({
      severity: severity,
      summary: summary,
      detail: detail,
      life: 3000
    });
  }

  onSubmit() {
    try{
      this.bookService.postBook(this.bookForm.value as unknown as Book).subscribe(() => {  //Deixar mais bonito 
        this.showToast('Sucess', 'Sucesso!', 'Livros Registrado Com Sucesso');
        this.bookForm.reset();
        this.bookService.triggerRefresh();
      
      })
    }catch(error: any){
      this.showToast('Sucess', 'Sucesso!', error.toString());
    }
  }

  onCancel(){
    this.getShowRegister.emit(false);
  }
}