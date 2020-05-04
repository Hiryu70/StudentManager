import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { StudentComponent } from './student/student.component';
import { StudentsListComponent } from './students-list/students-list.component';
import { StudentService } from './shared/student.service';
import { ModalModule } from 'ngx-bootstrap/modal';

@NgModule({
  declarations: [
    AppComponent,
    StudentComponent,
    StudentsListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ModalModule.forRoot()
  ],
  entryComponents: [ 
    StudentComponent 
  ],
  providers: [StudentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
