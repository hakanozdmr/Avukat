import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
    private url = 'http://localhost:7202/api/Users';
    constructor(private http: HttpClient){

    }
    getAllUsers() { 
        return this.http.get(this.url);
      }
    getUsersbyId(id) { 
        return this.http.get(`${this.url}/${id}`);
    }
    addUsers(user){
        return this.http.post(this.url,user);
    }
    updateUsers(user){
        return this.http.put(this.url,user);
    }
    deleteUsers(id){
        return this.http.delete(this.url+"/"+{id});
    }
}