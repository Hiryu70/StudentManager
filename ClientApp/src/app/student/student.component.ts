import { Component, OnInit } from '@angular/core';
import { Service, StudentVm, CreateStudentCommand, UpdateStudentCommand } from '../api/api.client.generated';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NicknameNotTaken } from '../validators/nickname-not-taken.validator';
import { StudentsListComponent } from '../students-list/students-list.component';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styles: []
})
export class StudentComponent implements OnInit {
  public student: StudentVm;
  public studentsListComponent: StudentsListComponent;
  registerForm: FormGroup;
  submitted = false;

  constructor(private bsModalRef: BsModalRef, private service: Service, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      name: [this.student.name, [Validators.required, Validators.maxLength(40)]],
      surname: [this.student.surname, [Validators.required, Validators.maxLength(40)]],
      patronymic: [this.student.patronymic, Validators.maxLength(60)],
      gender: [this.student.gender, Validators.required],
      nickname: [this.student.nickname, [Validators.minLength(6), Validators.maxLength(16)]]
    },{
      validator: NicknameNotTaken(this.service, this.student.id)
    });
  }

  get f() { return this.registerForm.controls; }

  public onSubmit() {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }
    
    if (this.student.id === undefined) {
      let createStudentCommand = new CreateStudentCommand();
      createStudentCommand.id = this.student.id;
      createStudentCommand.name = this.registerForm.controls['name'].value;
      createStudentCommand.surname = this.registerForm.controls['surname'].value;
      createStudentCommand.patronymic = this.registerForm.controls['patronymic'].value;
      createStudentCommand.gender = this.registerForm.controls['gender'].value;
      createStudentCommand.nickname = this.registerForm.controls['nickname'].value;
      this.service.create(createStudentCommand).subscribe(
        res => {
          this.studentsListComponent.refreshListFiltred();
          this.bsModalRef.hide();
        },
        err => {
          console.log(err);
        }
      )
    }
    else {
      let updateStudentCommand = new UpdateStudentCommand();
      updateStudentCommand.id = this.student.id;
      updateStudentCommand.name = this.registerForm.controls['name'].value;
      updateStudentCommand.surname = this.registerForm.controls['surname'].value;
      updateStudentCommand.patronymic = this.registerForm.controls['patronymic'].value;
      updateStudentCommand.gender = this.registerForm.controls['gender'].value;
      updateStudentCommand.nickname = this.registerForm.controls['nickname'].value;
      this.service.update(updateStudentCommand).subscribe(
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

  public closeModal() {
    this.bsModalRef.hide();
  }
}
