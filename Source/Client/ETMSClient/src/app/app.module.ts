import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AgGridModule } from 'ag-grid-angular';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { LoginComponent } from './components/account/login/login.component';
import {JwtInterceptor} from './helpers/jwtinterceptor';
import {Errorinterceptor} from './helpers/errorinterceptor';
import { RouterModule } from '@angular/router';
import {LayoutModule} from './layout/layout.module';
import { ForgotPasswordComponent } from './components/account/forgot-password/forgot-password.component';





@NgModule({
  declarations: [
    AppComponent,   
    HeaderComponent,
    FooterComponent,
    LoginComponent,   
    ForgotPasswordComponent
  ],
  imports: [
    BrowserModule,   
    FormsModule,    
    AgGridModule.withComponents([]),
    HttpClientModule,
    ReactiveFormsModule,  
    FlexLayoutModule,
    LayoutModule,
    AppRoutingModule,
 
  ],
  exports: [RouterModule],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: Errorinterceptor, multi: true },

],
  bootstrap: [AppComponent]
})
export class AppModule { }
