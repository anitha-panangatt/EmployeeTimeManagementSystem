import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  disableButton: boolean = false;
  returnUrl: string;
 

  constructor(private fb: FormBuilder,private authenticationService: AuthenticationService,private route: ActivatedRoute,
    private router: Router,
) { 
    if (this.authenticationService.currentUserValue) { 
      this.router.navigate(['/']);
  }

  }

 
  ngOnInit(): void {
    this.loginForm = this.fb.group({
      'UserName': ['abcd', Validators.required],
      'Password': ['1234', Validators.required]
    });

            // get return url from route parameters or default to '/'
            this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
            console.log("Return url : "+this.returnUrl);
 
  }
  login() {
    if (this.loginForm.valid) {
      console.log("login button clicked");
      this.disableButton = true;
       this.authenticationService.login(this.loginForm.value.UserName,this.loginForm.value.Password).subscribe(details => {
         console.log("Login response: "+JSON.stringify(details));
         if(details.role==="Admin")
         {
          console.log("Login response: ADmin");
          this.router.navigate(['/home/admindashboard']);
         }
         else
         {
          console.log("Login response: EMPLOYEE");
          this.router.navigate(['/home/admindashboard']);
         }
         
        if (details.isAuthenticated) {
          this.router.navigate(['/home']);
 
        } else {
          // this.disableButton = false;
          // this.sharedService.showToast('error','Login failed','Enter correct Username and Password');
        }
       });
    }
  }

  resetPassword() {
   // this.router.navigateByUrl('reset-password');
  }
}
