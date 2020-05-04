import { Component, OnInit } from '@angular/core';
import { StudentService } from '../shared/student.service';
import { Student } from '../shared/student.model';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styles: []
})
export class StudentComponent implements OnInit {
  public student: Student;
  
  constructor(private bsModalRef: BsModalRef, private service: StudentService) { }

  ngOnInit() {
  }

  public closeModal(){
    this.bsModalRef.hide();
  }

  public saveStudent(){
    this.service.nicknameIsFree(this.student.Nickname).subscribe( result => {
      if (result){
        if (this.student.Id === undefined){
          this.insertRecord();
        }
        else{
          this.updateRecord();
        }
      }
      else {
        console.error("Nickname exists");
      }
    }, error => console.error(error));
  }
  
  private insertRecord(){
    this.service.postStudent(this.student).subscribe(
      res => {
        this.service.refreshList();
        this.bsModalRef.hide();
      },
      err => {
        console.log(err);
      }
    )
  }

  private updateRecord(){
    this.service.putStudent(this.student).subscribe(
      res => {
        this.service.refreshList();
        this.bsModalRef.hide();
      },
      err => {
        console.log(err);
      }
    )
  }
}
