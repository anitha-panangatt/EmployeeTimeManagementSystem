import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {
  resetForm: FormGroup;
  currentUser: User;

  constructor(private fb: FormBuilder,private authenticationService: AuthenticationService,private employeeService : EmployeeService) { 
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    console.log(JSON.stringify(this.currentUser));
    console.log(this.currentUser.userName);
  }

  ngOnInit(): void {
    this.resetForm = this.fb.group({
      'userName':[this.currentUser.userName],
      'newPassword': ['', Validators.required],
      'confirmPassword': ['', Validators.required]
    });
  }

  resetPassword() {
    console.log("password change : ");
    console.log(JSON.stringify(this.resetForm.value.userName));
    this.employeeService.resetPassword(this.currentUser.userName,this.resetForm.value.newPassword).subscribe(response => {
      if (response) {
        console.log("password changed");
        // this.showNewUserCredentials = true;
        // this.sharedService.showToast('success', 'Save succeeded', 'New employee added sucessfully')
        this.resetForm.reset();
      }
    });
    //this.authenticationService.currentUser.userId

    // if (this.resetForm.valid && this.resetForm.controls['new'].value === this.resetForm.controls['confirm'].value)
      // this.resetService.reset(this.resetForm.controls['new'].value);
  }

}
