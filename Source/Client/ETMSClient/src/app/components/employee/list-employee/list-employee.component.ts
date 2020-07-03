import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeModel } from 'src/app/models/employee-model';
import {AgGridModule} from "ag-grid-angular";


@Component({
  selector: 'app-list-employee',
  templateUrl: './list-employee.component.html',
  styleUrls: ['./list-employee.component.scss']
})
export class ListEmployeeComponent implements OnInit {

  empList:EmployeeModel[];

  columnDefs = [
   
    {headerName: 'Id', field: 'userId' },
    {headerName: 'Name', field: 'userName' },
    { headerName: 'Actions', width: 250,
    template:
    `<button type="button" data-action-type="view" class="btn btn-dark mt-3 btn-sm">
       Edit
     </button>

    <button type="button" data-action-type="remove" class="btn btn-dark mt-3 btn-sm">
       Delete
    </button>`

    }
 
];

rowData = [
    { make: 'Toyota', model: 'Celica', price: 35000 },
    { make: 'Ford', model: 'Mondeo', price: 32000 },
    { make: 'Porsche', model: 'Boxter', price: 72000 }
];
name = 'Angular 6';
frameworkComponents: any;
rowDataClicked1 = {};
rowDataClicked2 = {};
  
  constructor(private employeeService : EmployeeService) { 
   
    this.employeeService.getAllEMployees().subscribe((employeeList) => {  
      this.empList = employeeList;  
    });  
  }

  ngOnInit(): void {
  }

  onBtnClick1(e) {
    this.rowDataClicked1 = e.rowData;
  }
  public onRowClicked(e) {
    if (e.event.target !== undefined) {
        let data = e.data;
        let actionType = e.event.target.getAttribute("data-action-type");

        switch(actionType) {
            case "view":
                return this.onActionViewClick(data);
            case "remove":
                return this.onActionRemoveClick(data);
        }
    }
}

public onActionViewClick(data: any){
    console.log("View action clicked", data);
}

public onActionRemoveClick(data: any){
    console.log("Remove action clicked", data);
}
}
