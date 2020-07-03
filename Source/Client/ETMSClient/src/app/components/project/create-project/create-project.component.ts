import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProjectService } from 'src/app/services/project.service';


@Component({
  selector: 'app-create-project',
  templateUrl: './create-project.component.html',
  styleUrls: ['./create-project.component.scss']
})
export class CreateProjectComponent implements OnInit {
  projectForm: FormGroup;
  addOrUpdate: boolean = false;

  constructor(private fb: FormBuilder,private projectService : ProjectService) { }
  ngOnInit(): void {
    this.projectForm = this.fb.group({
      'ProjectId': [0],
      'ProjectName': [null, Validators.required],
      'ProjectDescription': [null],
     
    });
  }
  addProject() {
    console.log('clicked');
    if (this.projectForm.valid) {
      console.log('projectForm valid'+this.projectForm);
      //this.empForm.value.mobile = this.empForm.value.mobile.toString();
      //this.empForm.value.projects = this.empForm.value.projects ? this.empForm.value.projects : [];
      this.projectService.addProject(this.projectForm.value).subscribe(response => {
        if (response) {
          console.log("project created");
          // this.showNewUserCredentials = true;
          // this.sharedService.showToast('success', 'Save succeeded', 'New employee added sucessfully')
          // this.homeService.getEmployees();
        }
      });
    }
  }

}
