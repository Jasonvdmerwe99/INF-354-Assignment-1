import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../services/data.service';
import { Course } from '../shared/course';

@Component({
  selector: 'app-edit-course',
  templateUrl: './edit-course.component.html',
  styleUrls: ['./edit-course.component.scss']
})
export class EditCourseComponent implements OnInit {
  EditCourseDetails: Course ={
    courseId: 0,
    name: '',
    description: '',
    duration: ''
  };

  constructor(private route: ActivatedRoute, private CourseService : DataService, private router: Router) { }
  

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
       const id = params.get('courseId');
       console.log(id);

       if(id){
        this.CourseService.getCoursebyID(Number(id)).subscribe({
          next: (response) => {
            this.EditCourseDetails = response;
            console.log(this.EditCourseDetails);
          }
        })
       }
      }
    })
  }

  UpdateCourse(){
    this.CourseService.updateCourse(this.EditCourseDetails.courseId, this.EditCourseDetails).subscribe({
      next: (response) => {
        this.router.navigate(['/courses']);
      }
    })
  }

}

