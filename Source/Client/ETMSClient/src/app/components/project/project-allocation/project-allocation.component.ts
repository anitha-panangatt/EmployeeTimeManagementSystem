import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ProjectModel } from 'src/app/models/project-model';
import { ProjectService } from 'src/app/services/project.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeModel } from 'src/app/models/employee-model';

@Component({
  selector: 'app-project-allocation',
  templateUrl: './project-allocation.component.html',
  styleUrls: ['./project-allocation.component.scss']
})
export class ProjectAllocationComponent implements OnInit {
  projectList:ProjectModel[];
  empList:EmployeeModel[];
  
  constructor(private projectService : ProjectService,private employeeService : EmployeeService) { 
    this.projectService.getAllProjects().subscribe((_projectList) => {  
      console.log(_projectList);
      this.projectList = _projectList;  
    });  
    this.employeeService.getAllEMployees().subscribe((employeeList) => {  
      console.log(employeeList);
      this.empList = employeeList;  
    });  

  }

  ngOnInit(): void {
  }
  
  
  form = new FormGroup({
    projectId: new FormControl('', Validators.required),
    employeeId: new FormControl('', Validators.required)
  });
  
  get f(){
    return this.form.controls;
  }
  
  submit(){
    console.log(this.form.value);
    
    this.projectService.allocateProjectToEmployee(this.form.value).subscribe(response => {
      if (response) {
        console.log("project allocated to employee");
        // this.showNewUserCredentials = true;
        // this.sharedService.showToast('success', 'Save succeeded', 'New employee added sucessfully')
        // this.homeService.getEmployees();
      }
    });
  }


}
