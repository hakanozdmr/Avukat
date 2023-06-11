import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AnswersService {
    private url = 'http://localhost:7202/api/Answers';
    constructor(private http: HttpClient){

    }
  getAnswers(userId) { 
    return this.http.get(this.url+"/"+userId);
  }
  AddAnswers(answer){
    return this.http.post(this.url,answer);
  }
}