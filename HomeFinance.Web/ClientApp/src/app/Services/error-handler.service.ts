import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { MatDialog} from '@angular/material';
import {Observable, of } from 'rxjs';
import {ErrorDialogComponent} from '../shared/error-dialog/error-dialog.component';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {

  public errorMessage: string = '';
  public dialogConfig: MatDialog;

  constructor(private dialog: MatDialog) { }

  public handleError<T> (method='', result?: T) {
      return (error: any): Observable<T> => {
          this.createErrorMessage(error, method);

          const data = { 'errorStatus': error.status || null, method: method, 'errorMessage': this.errorMessage }; 

          this.dialog.open(ErrorDialogComponent,  {
            width: '450px',
            data: data
          });          
      return of(result as T);
    };
  }

  private createErrorMessage(error: HttpErrorResponse, method) {
    console.log(`Error: Status=${error.status}, Message=${error.message} or =${error.toString()}`)
    switch(error.status){
      case 400:
          this.errorMessage = " Bad Request: " + error.url;
        break;
      case 404:
          this.errorMessage = " Not Found: " + error.url;
          break;
      case 500:
          if(method === 'getsummary'){
            this.errorMessage = "Server Error - Views need to be created"
          }
          else {
            this.errorMessage = "Server Error";            
          }
        break;
      default:
          this.errorMessage = error.message || error.toString(); 
        break;          
    }
  } 

}