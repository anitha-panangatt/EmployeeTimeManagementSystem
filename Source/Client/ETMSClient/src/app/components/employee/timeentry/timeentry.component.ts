import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { User } from 'src/app/models/user';
import { ProjectService } from 'src/app/services/project.service';
import { ProjectModel } from 'src/app/models/project-model';
import { FormBuilder, FormGroup } from '@angular/forms';
import {TimeEntry} from 'src/app/models/time-entry';
import {TimeEntryService} from 'src/app/services/time-entry.service'


@Component({
  selector: 'app-timeentry',
  templateUrl: './timeentry.component.html',
  styleUrls: ['./timeentry.component.scss']
})
export class TimeentryComponent implements OnInit {
  timeEntryForm:FormGroup;
  currentUser: User;
  empId:string;
  projectList:ProjectModel[];

  timeEntryList:TimeEntry[];

  columnDefs = [
   
    {headerName: 'Date', field: 'projectDate' },
    {headerName: 'Project Name', field: 'projectName' },
    {headerName: 'Comment', field: 'taskComment' }, 
    {headerName: 'Hours', field: 'hours' },    
    { headerName: 'Actions', width: 250,
    template:
    `<button type="button" data-action-type="view" class="btn btn-dark mt-3 btn-sm">
       Edit
     </button>

    <button type="button" data-action-type="remove" class="btn btn-dark mt-3 btn-sm">
       Delete
    </button>`

    }];
  
  constructor( private authenticationService: AuthenticationService,private projectService : ProjectService,private fb: FormBuilder,private timeEntryService:TimeEntryService) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);

    this.projectService.getEmployeeProjects(this.empId).subscribe((_projectList) => {  
      console.log(_projectList);
      this.projectList = _projectList;  
    });  

    this.timeEntryService.getTimeEntry().subscribe((_timeEntryList) => {  
      console.log(_timeEntryList);
      this.timeEntryList = _timeEntryList;  
    });  
   }

   ngOnInit(): void {
    this.timeEntryForm = this.fb.group({
      'userId': [28],
      'ProjectId': [0],
      'Hours': [null],   
      'TaskComment':[null],   
      'projectList': this.projectList
    });
  }
  addTimeEntry()
  {
    console.log(JSON.stringify(this.timeEntryForm.value));
    this.timeEntryService.createTimeEntry(this.timeEntryForm.value).subscribe(response => {
      if (response) {
        console.log("timeEntry created");
        // this.showNewUserCredentials = true;
        // this.sharedService.showToast('success', 'Save succeeded', 'New employee added sucessfully')
        // this.homeService.getEmployees();
      }
    });
  }
}
