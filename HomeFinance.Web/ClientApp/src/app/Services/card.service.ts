import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable } from 'rxjs';
import { catchError} from 'rxjs/operators';

import { Card } from '../models/card.model'; 
import { ErrorHandlerService } from '../services/error-handler.service';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CardService {
  private cardUrl =environment.apiEndpoint + '/api/card';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, private errorService: ErrorHandlerService) { }

  getCards(): Observable<Card[]> {
    const url = `${this.cardUrl}/getcards`;
    return this.http.get<Card[]>(url).pipe(
      catchError(this.errorService.handleError<Card[]>('getCards'))
    );
  }

  getCard(id: number): Observable<Card> {
    const url = `${this.cardUrl}/${id}`;
    return this.http.get<Card>(url).pipe(
      catchError(this.errorService.handleError<Card>(`getCard id=${id}`))
    );
  }

  addCard (card: Card): Observable<number> {
    const url =`${this.cardUrl}`;
    return this.http.post<number>(url, card, this.httpOptions).pipe(
      catchError(this.errorService.handleError<number>('addCard'))
    );
  }

  updateCard (card: Card): Observable<any> {
    const id = card.id;
    const url = `${this.cardUrl}/${id}`;
      return this.http.put(url, card, this.httpOptions).pipe(    
      catchError(this.errorService.handleError<any>(`updateCard id=${id}`))
    );
  }

}