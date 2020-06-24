import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/service/employee.service';
import { Employee } from 'src/app/Model/employee';


@Component({
  selector: 'app-list-employee',
  templateUrl: './list-employee.component.html',
  styleUrls: ['./list-employee.component.css']
})
export class ListEmployeeComponent implements OnInit {

  empList:Employee[];
  
  constructor(private employeeService : EmployeeService) { 
    this.employeeService.getAllEMployees().subscribe((employeeList) => {  
      this.empList = employeeList;  
    });  
  }

  ngOnInit(): void {
   
  }

}
