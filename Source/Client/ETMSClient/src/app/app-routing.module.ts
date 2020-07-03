import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {Authguard} from './helpers/authguard';
import { HomeComponent } from './layout/home/home.component';
import { LoginComponent } from './components/account/login/login.component';
import { ForgotPasswordComponent } from './components/account/forgot-password/forgot-password.component';



const routes: Routes =[
   
  //{
    // path: '',
    // component: HomeComponent,
    // canActivateChild:[Authguard]
    //    },
        {
          path: 'home',
          component: HomeComponent,
          canActivateChild:[Authguard]
             },
        {
          path: 'login',
          component: LoginComponent
             },
             {  path: 'forgot',
             component: ForgotPasswordComponent}

];

//const routes: Routes = [];,
 // {path:'allocateproject',component:AllocationProjectComponent}


@NgModule({
  imports: [ RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
