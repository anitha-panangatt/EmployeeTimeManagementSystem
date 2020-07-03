import { Component } from '@angular/core';
import { User } from './models/user';
import { Router } from '@angular/router';
import { AuthenticationService } from './services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ETMSClient';
  currentUser: User;
  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
) {
  console.log("AppComponent :"+this.currentUser);
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
}

logout() {
  console.log("AppComponent Logout:");
    this.authenticationService.logout();
    this.router.navigate(['/login']);
}


}
