import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CoursesComponent } from './course/courses.component';
import { AddCourseComponent } from './add-course/add-course.component';
import { EditCourseComponent } from './edit-course/edit-course.component';


const routes: Routes = [
  {path: 'courses', component: CoursesComponent}, 
  {path: 'add-course', component: AddCourseComponent}, 
  {path: 'edit-course/:courseId', component: EditCourseComponent},
  {path: '', redirectTo: '/courses', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
