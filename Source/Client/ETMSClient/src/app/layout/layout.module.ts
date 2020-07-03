import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AgGridModule } from 'ag-grid-angular';
import { RouterModule } from '@angular/router';

import { LayoutRoutingModule } from './layout-routing.module';
import { HomeComponent } from './home/home.component';
import { TimeentryComponent } from '../components/employee/timeentry/timeentry.component';
import {EmployeeDashboardComponent} from '../components/employee/employee-dashboard/employee-dashboard.component';
import {ChangePasswordComponent} from '../components/account/change-password/change-password.component';
import { CreateProjectComponent } from '../components/project/create-project/create-project.component';
import { ListProjectComponent } from '../components/project/list-project/list-project.component';
import { ProjectAllocationComponent } from '../components/project/project-allocation/project-allocation.component';
import { CreateEmployeeComponent } from '../components/employee/create-employee/create-employee.component';
import { ListEmployeeComponent } from '../components/employee/list-employee/list-employee.component';
import { AdminDashboardComponent } from '../components/admin/admin-dashboard/admin-dashboard.component';


@NgModule({
  declarations: [HomeComponent,CreateEmployeeComponent,ListEmployeeComponent,
    TimeentryComponent,EmployeeDashboardComponent,ChangePasswordComponent ,CreateProjectComponent,
    ListProjectComponent,
    ProjectAllocationComponent,AdminDashboardComponent],
  imports: [
    CommonModule,   
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    AgGridModule.withComponents(),
    LayoutRoutingModule
 
  ]
})
export class LayoutModule { }
