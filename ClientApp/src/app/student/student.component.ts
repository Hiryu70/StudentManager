import { Component, OnInit } from '@angular/core';
import { StudentService } from '../shared/student.service';
import { Student } from '../shared/student.model';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NicknameNotTaken } from '../validators/nickname-not-taken.validator';
import { StudentList } from '../shared/studentList.model';
import { StudentsListComponent } from '../students-list/students-list.component';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styles: []
})
export class StudentComponent implements OnInit {
  public student: Student;
  public studentsListComponent: StudentsListComponent;
  registerForm: FormGroup;
  submitted = false;

  constructor(private bsModalRef: BsModalRef, private service: StudentService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      name: [this.student.Name, [Validators.required, Validators.maxLength(40)]],
      surname: [this.student.Surname, [Validators.required, Validators.maxLength(40)]],
      patronymic: [this.student.Patronymic, Validators.maxLength(60)],
      gender: [this.student.Gender, Validators.required],
      nickname: [this.student.Nickname, [Validators.minLength(6), Validators.maxLength(16)]]
    },{
      validator: NicknameNotTaken(this.service, this.student.Id)
    });
  }

  get f() { return this.registerForm.controls; }

  public onSubmit() {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    this.student.Name = this.registerForm.controls['name'].value;
    this.student.Surname = this.registerForm.controls['surname'].value;
    this.student.Patronymic = this.registerForm.controls['patronymic'].value;
    this.student.Gender = this.registerForm.controls['gender'].value;
    this.student.Nickname = this.registerForm.controls['nickname'].value;
    
    this.saveStudent();
  }

  public closeModal() {
    this.bsModalRef.hide();
  }

  public saveStudent() {
    if (this.student.Id === undefined) {
      this.insertRecord();
    }
    else {
      this.updateRecord();
    }
  }

  private insertRecord() {
    this.service.postStudent(this.student).subscribe(
      res => {
        this.studentsListComponent.refreshListFiltred();
        this.bsModalRef.hide();
      },
      err => {
        console.log(err);
      }
    )
  }

  private updateRecord() {
    this.service.putStudent(this.student).subscribe(
      res => {
        this.studentsListComponent.refreshListFiltred();
        this.bsModalRef.hide();
      },
      err => {
        console.log(err);
      }
    )
  }
}
