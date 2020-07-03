import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProjectModel } from '../models/project-model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  
  constructor(private http: HttpClient) { 

  }

  getAllProjects(): Observable<ProjectModel[]> {

    return this.http.get<ProjectModel[]>('https://localhost:44345/api/Project/GetProjects');
  
  }

  addProject(project) {
    console.log(project);   
    
    return this.http.post('https://localhost:44345/api/project/CreateProject', project);
  }
  allocateProjectToEmployee(allocationInfo) {
    console.log(allocationInfo);   
    
    return this.http.post('https://localhost:44345/api/project/AllocateProjectToEmployee', allocationInfo);
  }

  getEmployeeProjects(employeeId)
  {
    //note - need to pass employee id
    return this.http.get<ProjectModel[]>('https://localhost:44345/api/Project/GetProjects');
  }

}