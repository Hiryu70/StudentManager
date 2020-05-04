import { Student } from './student.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  list: Student[];
  studentsCount: number = 0;
  readonly rootUrl = 'http://localhost:5000/api';
  constructor(private http:HttpClient) { }

  postStudent(student: Student){
    return this.http.post(this.rootUrl + '/Student', student);
  }

  putStudent(student: Student){
    return this.http.put(this.rootUrl + '/Student/' + student.Id, student);
  }

  deleteStudent(id){
    return this.http.delete(this.rootUrl + '/Student/' + id);
  }

  getStudent(id){
    return this.http.get(this.rootUrl + '/Student/' + id);
  }

  refreshList(){
    this.http.get(this.rootUrl + '/Student')
    .toPromise()
    .then(res => {
      this.list = res as Student[];
      this.studentsCount = this.list.length;
    });
  }

  nicknameIsFree(nickname){
    return this.http.delete(this.rootUrl + '/nicknameIsFree/' + nickname);
  }
}
