import { Injectable, OnInit, Component } from '@angular/core';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { tap, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { IComputer } from '../interfaces/computer';
import { MessageService } from './message.service';
import { baseApiUrl } from '../../constants';

@Injectable({
  providedIn: 'root'
})
export class ComputerService {

  private computerUrl = baseApiUrl + '/Computers';

  constructor(
    private http: HttpClient,
    private messageService: MessageService,
  ) { }

  getComputers(): Observable<IComputer[]> {
    return this.http.get<IComputer[]>(this.computerUrl)
      .pipe(
        tap(_ => this.log('fetched computers')),
        catchError(this.handleError<IComputer[]>('getComputers', [])));
  }

  getComputer(id: number) {
    return this.http.get(this.computerUrl + '/' + id);
  }

  private log(message: string) {
    this.messageService.log(`ComputerService: ${message}`);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      this.log(`${operation} failed: ${error.message}`);
      this.messageService.add(error.error.message);

      return of(result as T);
    }
  }
}
