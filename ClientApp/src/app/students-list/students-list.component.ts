import { Component, OnInit } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { StudentComponent } from '../student/student.component';
import { Service, StudentVm, GetStudentsListQuery } from '../api/api.client.generated';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styles: []
})
export class StudentsListComponent implements OnInit {
  public students: StudentVm[];
  public totalStudents: number;
  public filteredStudents: number;
  public searchString: string;
  
  constructor(private service: Service, private modalService: BsModalService) { }

  ngOnInit() {
    this.refreshList();
  }

  public newStudent(){
      const initialState = {
        student: new StudentVm(),
        studentsListComponent: this
      };
      this.modalService.show(StudentComponent, { initialState });
  }

  onKey(event: any) {
    this.searchString = event.target.value;
    this.refreshListFiltred();
  }

  public editStudent(student: StudentVm) {
    this.service.get(student.id).subscribe(result => {
      const initialState = {
        student: result,
        studentsListComponent: this
      };
      this.modalService.show(StudentComponent, { initialState });
    }, error => console.error(error));
  }

  public onDelete(id) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.delete(id).subscribe(() => {
        this.refreshList();
      }, error => {
        console.log(error);
      })
    }
  }

  refreshList(){
    this.service.getAll().subscribe(result => {
      this.students = result.students;
      this.filteredStudents = result.students.length;
      this.totalStudents = result.totalCount;
    });
  }

  refreshListFiltred(){
    let query = new GetStudentsListQuery();
    query.searchString = this.searchString;

    this.service.getAllFiltered(query).subscribe(result => {
      this.students = result.students;
      this.filteredStudents = result.students.length;
      this.totalStudents = result.totalCount;
    });
  }
}
