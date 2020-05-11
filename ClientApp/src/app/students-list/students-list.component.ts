import { Component, OnInit } from '@angular/core';
import { StudentService } from '../shared/student.service';
import { Student } from '../shared/student.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { StudentComponent } from '../student/student.component';
import { StudentList } from '../shared/studentList.model';
import { FilterParameters } from '../shared/fiterParameters.model';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styles: []
})
export class StudentsListComponent implements OnInit {
  private bsModalRef: BsModalRef;
  public studentList: StudentList = new StudentList();
  public searchString: string;
  
  constructor(private service: StudentService, private modalService: BsModalService) { }

  ngOnInit() {
    this.refreshList();
  }

  public newStudent(){
      const initialState = {
        student: new Student(),
        studentsListComponent: this
      };
      this.bsModalRef = this.modalService.show(StudentComponent, { initialState });
  }

  onKey(event: any) {
    this.searchString = event.target.value;
    this.refreshListFiltred();
  }

  public editStudent(student: Student) {
    this.service.getStudent(student.Id).subscribe(result => {
      const initialState = {
        student: result,
        studentsListComponent: this
      };
      this.bsModalRef = this.modalService.show(StudentComponent, { initialState });
    }, error => console.error(error));
  }

  public onDelete(id) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteStudent(id).subscribe(res => {
        this.refreshList();
      }, error => {
        console.log(error);
      })
    }
  }

  refreshList(){
    this.service.getAll().toPromise()
    .then(result => {
      this.studentList = result as StudentList;
    });
  }

  refreshListFiltred(){
    let filteredParameters = new FilterParameters();
    filteredParameters.SearchString = this.searchString;

    this.service.getAllFiltered(filteredParameters).toPromise()
    .then(result => {
      this.studentList = result as StudentList;
    });
  }
}
