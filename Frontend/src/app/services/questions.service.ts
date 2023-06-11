import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class QuestionService {
    private url = 'http://localhost:7202/api/Questions';
    constructor(private http: HttpClient){

    }
  getQuestions(lawyerId) { 
    return this.http.get(this.url+"/"+lawyerId);
  }
  AddQuestion(question){
    return this.http.post(this.url,question);
  }
}