import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
    private url = 'http://localhost:7202/api/Categories';
    constructor(private http: HttpClient){

    }
    getAllCategories() { 
        return this.http.get(this.url);
      }
    getCategorieswithLawyers(id) { 
        return this.http.get(this.url+"/"+{id}+"/lawyers");
    }
    getCategoriesbyId(id) { 
        return this.http.get(this.url+"/"+{id});
    }
    addCategories(category){
        return this.http.post(this.url,category);
    }
    updateCategories(category){
        return this.http.put(this.url,category);
    }
    deleteCategories(id){
        return this.http.delete(this.url+"/"+{id});
    }
}