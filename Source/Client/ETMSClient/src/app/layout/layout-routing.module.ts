import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { ListEmployeeComponent } from '../components/employee/list-employee/list-employee.component';
import { CreateEmployeeComponent } from '../components/employee/create-employee/create-employee.component';

import { ProjectAllocationComponent } from '../components/project/project-allocation/project-allocation.component';
import { TimeentryComponent } from '../components/employee/timeentry/timeentry.component';
import { EmployeeDashboardComponent } from '../components/employee/employee-dashboard/employee-dashboard.component';
import { ChangePasswordComponent } from '../components/account/change-password/change-password.component';
import { CreateProjectComponent } from '../components/project/create-project/create-project.component';
import { ListProjectComponent } from '../components/project/list-project/list-project.component';
import { AdminDashboardComponent } from '../components/admin/admin-dashboard/admin-dashboard.component';
import { Authguard } from '../helpers/authguard';

const routes: Routes = [
  {path: 'home',
        component: HomeComponent,  
        canActivateChild:[Authguard],      
        children: [
          {path:'admindashboard',component:AdminDashboardComponent},
          {path:'employeedashboard',component:EmployeeDashboardComponent},
           {path:'list',component:ListEmployeeComponent},
           {path:'create',component:CreateEmployeeComponent }, 
           {path:'createproject',component:CreateProjectComponent},
            {path:'projectlist',component:ListProjectComponent},
           {path:'allocate',component:ProjectAllocationComponent},
           {path:'timeentry',component:TimeentryComponent},
           {path:'changepassword',component:ChangePasswordComponent}

           
        ]
      }
  //          {path:'list',component:ListEmployeeComponent, canActivate: [Authguard],},
  //          {path:'create',component:CreateEmployeeComponent , canActivate: [Authguard]}, 
  // {path:'createproject',component:CreateProjectComponent, canActivate: [Authguard]},
  // {path:'projectlist',component:ListProjectComponent, canActivate: [Authguard]}  ,
  // {path:'allocate',component:ProjectAllocationComponent, canActivate: [Authguard]}
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
