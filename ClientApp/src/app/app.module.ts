import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';

import { Service, API_BASE_URL } from './api/api.client.generated';

import { AppComponent } from './app.component';
import { StudentComponent } from './student/student.component';
import { StudentsListComponent } from './students-list/students-list.component';
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
    ReactiveFormsModule,
    HttpClientModule,
    ModalModule.forRoot()
  ],
  entryComponents: [ 
    StudentComponent 
  ],
  providers: [
    { provide: API_BASE_URL, useValue: "http://localhost:5000" },
    Service],
  bootstrap: [AppComponent]
})
export class AppModule { }
