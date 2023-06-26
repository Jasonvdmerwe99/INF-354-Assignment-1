import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, Subject } from 'rxjs';
import { Course } from '../shared/course';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  apiUrl = 'http://localhost:5116/api/'

  httpOptions ={
    headers: new HttpHeaders({
      ContentType: 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { 
  }

  GetCourses(): Observable<any>{
    return this.httpClient.get(`${this.apiUrl}Course/GetAllCourses`)
    .pipe(map(result => result))
  }

addCourse(AddCourseRequest: Course){
  return this.httpClient.post<Course>(`${this.apiUrl}Course/CourseAdd`, AddCourseRequest)
  .pipe(map(result => result))
}

  getCoursebyID(courseId: Number): Observable<Course>{
    return this.httpClient.get<Course>(`${this.apiUrl}Course/CourseEdit` + courseId)
  }

  updateCourse(courseId: Number, UpdateCourseRequest: Course): Observable<Course>{
    return this.httpClient.put<Course>(`${this.apiUrl}Course/CourseEditSave` + courseId, UpdateCourseRequest)
  }

  deleteCourse(courseId: Number): Observable<Course>{
    return this.httpClient.delete<Course>(`${this.apiUrl}Course/CourseDelete` + courseId)
  }

}



