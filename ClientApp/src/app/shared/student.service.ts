import { Student } from './student.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FilterParameters } from './fiterParameters.model';
import { CheckNickname } from './checkNickname.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  readonly basePath = 'http://localhost:5000';
  constructor(private http:HttpClient) { }

  getAll(){
    return this.http.get(`${this.basePath}/api/Student/GetAll/`)
  }

  getAllFiltered(filterParameters: FilterParameters){
    return this.http.post(`${this.basePath}/api/Student/GetAllFiltered/`, filterParameters);
  }

  getStudent(id){
    return this.http.get(`${this.basePath}/api/Student/Get/${id}`);
  }

  putStudent(student: Student){
    return this.http.put(`${this.basePath}/api/Student/Update/`, student);
  }

  postStudent(student: Student){
    return this.http.post(`${this.basePath}/api/Student/Create/`, student);
  }

  deleteStudent(id){
    return this.http.delete(`${this.basePath}/api/Student/Delete/${id}`);
  }

  nicknameNotTaken(checkNickname: CheckNickname){
    return this.http.post(`${this.basePath}/api/Student/CheckNicknameNotTaken/`, checkNickname);
  }
}
