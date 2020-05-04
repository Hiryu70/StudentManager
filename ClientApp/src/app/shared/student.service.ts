import { Student } from './student.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  formData: Student = new Student();
  list: Student[];
  studentsCount: number = 0;
  readonly rootUrl = 'http://localhost:5000/api';
  constructor(private http:HttpClient) { }

  postStudent(){
    return this.http.post(this.rootUrl + '/Student', this.formData);
  }

  putStudent(){
    return this.http.put(this.rootUrl + '/Student/' + this.formData.Id, this.formData);
  }

  deleteStudent(id){
    return this.http.delete(this.rootUrl + '/Student/' + id);
  }

  refreshList(){
    this.http.get(this.rootUrl + '/Student')
    .toPromise()
    .then(res => {
      this.list = res as Student[];
      this.studentsCount = this.list.length;
    });
  }
}
