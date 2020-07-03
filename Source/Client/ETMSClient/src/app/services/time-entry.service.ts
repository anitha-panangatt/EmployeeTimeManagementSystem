import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TimeEntry } from '../models/time-entry';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TimeEntryService {
  
  constructor(private http: HttpClient) { 

  }

  createTimeEntry(timeEntry)
  {
    console.log(JSON.stringify(timeEntry));
    return this.http.post('https://localhost:44345/api/TimeSheet/CreateTimeEntry', timeEntry);
  }

  getTimeEntry(): Observable<TimeEntry[]>
  {
    return this.http.get<TimeEntry[]>('https://localhost:44345/api/TimeSheet/GetTimeEntry');
  }
}
