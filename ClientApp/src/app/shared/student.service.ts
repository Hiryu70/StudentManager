import { Student } from './student.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StudentList } from './studentList.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  public studentList: StudentList = new StudentList();

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
    .then(result => {
      this.studentList = result as StudentList;
    });
  }

  refreshListFiltred(searchString){
    this.http.post(this.rootUrl + '/Student/filtred',{
      SearchString: searchString
    })
    .toPromise()
    .then(result => {
      this.studentList = result as StudentList;
    });
  }

  nicknameNotTaken(nickname: string, studentId: string){
    return this.http.post(this.rootUrl + '/Student/nicknameNotTaken',{
      Nickname: nickname,
      StudentId: studentId
    });
  }
}
