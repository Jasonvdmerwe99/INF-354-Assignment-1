import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../services/data.service';
import { Course } from '../shared/course';

@Component({
  selector: 'app-add-course',
  templateUrl: './add-course.component.html',
  styleUrls: ['./add-course.component.scss']
})
export class AddCourseComponent implements OnInit {

  AddCourseRequest: Course ={
    courseId: 0,
    name: '',
    description: '',
    duration: ''
  }
  constructor(private CourseService: DataService, private router: Router) { }

  ngOnInit(): void {
  }

  AddCourse(){
    this.CourseService.addCourse(this.AddCourseRequest)
    .subscribe({
      next: (courseadded) =>{
        console.log(courseadded)
        this.router.navigate(['/courses'])
      }
    });
  }


}
