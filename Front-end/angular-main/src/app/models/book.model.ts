import { Category } from "./category.model";

export interface Book {
    id?: string;
    title: string;
    category: Category; // Category can be an object or a string
    author: string;
    value: number;
}