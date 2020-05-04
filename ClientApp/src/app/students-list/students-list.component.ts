import { Component, OnInit } from '@angular/core';
import { StudentService } from '../shared/student.service';
import { Student } from '../shared/student.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { StudentComponent } from '../student/student.component';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styles: []
})
export class StudentsListComponent implements OnInit {
  private bsModalRef: BsModalRef;

  constructor(private service: StudentService, private modalService: BsModalService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  public newStudent(){
      const initialState = {
        student: new Student()
      };
      this.bsModalRef = this.modalService.show(StudentComponent, { initialState });
  }

  public editStudent(student: Student) {
    this.service.getStudent(student.Id).subscribe(result => {
      const initialState = {
        student: result
      };
      this.bsModalRef = this.modalService.show(StudentComponent, { initialState });
    }, error => console.error(error));
  }

  public onDelete(id) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteStudent(id).subscribe(res => {
        this.service.refreshList();
      }, error => {
        console.log(error);
      })
    }
  }
}
