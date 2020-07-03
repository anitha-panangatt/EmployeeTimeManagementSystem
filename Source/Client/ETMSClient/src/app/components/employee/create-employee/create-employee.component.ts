import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EmployeeService } from 'src/app/services/employee.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-create-employee',
  templateUrl: './create-employee.component.html',
  styleUrls: ['./create-employee.component.scss']
})
export class CreateEmployeeComponent implements OnInit {
  empForm: FormGroup;
  addOrUpdate: boolean = false;
  submitted :boolean= false;

  constructor(private fb: FormBuilder,private employeeService : EmployeeService) { }

  ngOnInit(): void {
    this.empForm = this.fb.group({
      'userId': [0],
      'FirstName':[null, Validators.required],
      'LastName':[null, Validators.required],
      'MobileNumber': [null, Validators.required],
      'Designation': [null],
      'Address': [null],
      'City': [],
      'State': [],
      'Email': ['', Validators.required]
     

    });
  }
  addEmployee() {
    this.submitted = true;
    console.log(JSON.stringify(this.empForm.value));
    if (this.empForm.valid) {
      console.log('empForm valid'+this.empForm);
      //this.empForm.value.mobile = this.empForm.value.mobile.toString();
      //this.empForm.value.projects = this.empForm.value.projects ? this.empForm.value.projects : [];
      this.employeeService.addEmployee(this.empForm.value).subscribe(response => {
        if (response) {
          console.log("employee created");
          Swal.fire({
            text: 'Employee created successfully.',
            icon: 'success'
          });
          this.empForm.reset();
          this.submitted = false;
          // this.showNewUserCredentials = true;
          // this.sharedService.showToast('success', 'Save succeeded', 'New employee added sucessfully')
          // this.homeService.getEmployees();
        }
      });
    }
  }

}
