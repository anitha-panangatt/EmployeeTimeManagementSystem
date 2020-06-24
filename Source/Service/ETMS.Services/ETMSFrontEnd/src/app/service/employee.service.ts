import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../Model/employee';
import { catchError, map, tap } from 'rxjs/operators';






@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private getEmployeeUrl = 'api/employees';  // URL to web api

  constructor(private http: HttpClient) { 

  }

  getAllEMployees(): Observable<Employee[]> {

    return this.http.get<Employee[]>('https://localhost:44345/api/employee/GetEmployees');
  
  }


}
  

