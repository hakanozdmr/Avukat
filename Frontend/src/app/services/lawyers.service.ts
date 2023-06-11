import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class LawyersService {
    private url = 'http://localhost:7202/api/Lawyers';
    constructor(private http: HttpClient){

    }
    getAllLawyers() { 
        return this.http.get(this.url);
      }
    getLawyerswithCategory(id) { 
        return this.http.get(this.url+"/"+{id}+"/categories");
    }
    getLawyersbyId(id) { 
        return this.http.get(this.url+"/"+{id});
    }
    addLawyers(lawyer){
        return this.http.post(this.url,lawyer);
    }
    updateLawyers(lawyer){
        return this.http.put(this.url,lawyer);
    }
    deleteLawyers(id){
        return this.http.delete(this.url+"/"+{id});
    }
}