import { Component, OnInit } from '@angular/core';
import { StudentService } from '../shared/student.service';
import { Student } from '../shared/student.model';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styles: []
})
export class StudentsListComponent implements OnInit {

  constructor(private service: StudentService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(student:Student){
    this.service.formData = Object.assign({},student);
  }

  onDelete(id){
    if (confirm('Are you sure to delete this record?')){

    
    this.service.deleteStudent(id)
    .subscribe(
      res => {
        this.service.refreshList();
      },
      err => {
        console.log(err);
      })
  }
}
}
