import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EmployeeModel } from '../models/employee-model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {


  constructor(private http: HttpClient) { 

  }

  getAllEMployees(): Observable<EmployeeModel[]> {

    return this.http.get<EmployeeModel[]>('https://localhost:44345/api/employee/GetEmployees');
  
  }

  addEmployee(employee) {
    console.log(employee);   
    
    return this.http.post('https://localhost:44345/api/employee/CreateEmployee', employee);
  }

  resetPassword(userName,password)
  {
    console.log("reset password ");
    const opts = { params: new HttpParams({fromString: "userName="+userName+"&pwd="+password}) };
    return this.http.get("https://localhost:44345/api/employee/ResetPassword", opts);
 
    
  }
}
