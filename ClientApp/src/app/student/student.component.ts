import { Component, OnInit } from '@angular/core';
import { StudentService } from '../shared/student.service';
import { NgForm } from '@angular/forms';
import { Student } from '../shared/student.model';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styles: []
})
export class StudentComponent implements OnInit {
  constructor(private service:StudentService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?:NgForm){
    if (form != null){
      form.resetForm();
    }
    this.service.formData = new Student();
  }

  onSubmit(form:NgForm){
    if (this.service.formData.Id === undefined){
      this.insertRecord(form);
    }
    else{
      this.updateRecord(form);
    }

  }
  
  insertRecord(form: NgForm){
    this.service.postStudent().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }

  updateRecord(form: NgForm){
    this.service.putStudent().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }
}
