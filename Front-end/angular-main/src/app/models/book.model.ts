import { Category } from "./category.model";

export interface Book {
    id?: string;
    title: string;
    category: Category; 
    author: string;
    value: number;
}