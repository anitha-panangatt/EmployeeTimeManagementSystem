import { Component, OnInit } from '@angular/core';
import { ProjectModel } from 'src/app/models/project-model';
import { ProjectService } from 'src/app/services/project.service';

@Component({
  selector: 'app-list-project',
  templateUrl: './list-project.component.html',
  styleUrls: ['./list-project.component.scss']
})
export class ListProjectComponent implements OnInit {
  projectList:ProjectModel[];

  columnDefs = [   
    {headerName: 'Id', field: 'projectId' },
    {headerName: 'Project Name', field: 'projectName' },
    {headerName: 'Description', field: 'projectDescription' }
];
  constructor(private projectService : ProjectService) {
    this.projectService.getAllProjects().subscribe((employeeList) => {  
      console.log(employeeList);
      this.projectList = employeeList;  
    });  
   }

  ngOnInit(): void {
  }

}
