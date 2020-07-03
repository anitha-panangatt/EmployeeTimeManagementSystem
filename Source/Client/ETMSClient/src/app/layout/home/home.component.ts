import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { User } from 'src/app/models/user';
import { Role } from 'src/app/models/role';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  title = 'ETMSClient';
  currentUser: User;
  constructor( private router: Router, private authenticationService: AuthenticationService) { 
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit(): void {
  }

  logout():void{
    console.log("AppComponent Logout:");
    this.authenticationService.logout();
    this.router.navigate(['./login']);
  }
  get isAdmin() {
    // console.log("User role : "+this.currentUser.role.toString());
    // console.log("Role.Admin : "+Role.Admin.toString());
    //return this.currentUser && this.currentUser.role.toString() === Role.Admin.toString();
   return true;
}


}
