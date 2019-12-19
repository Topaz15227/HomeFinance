import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import {Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { CardPay } from '../models/card-pay.model';
import { ViewStorePay } from '../models/view-store-pay.model';
import { StorePayView } from '../models/store-pay-view.model'
import { StorePay } from '../models/store-pay.model';
import { ClosingView, ClosingListData } from '../models/closing-view.model';
import { ArchiveListView } from '../models/archive-list-view.model';
import { ClosingPayListView } from '../models/closing-pay-list-view.model';
import { CardItem } from '../models/card-item.model';
import { StoreItem } from '../models/store-item.model'; 
import { Closing} from '../models/closing.model'; 

import { ErrorHandlerService } from '../services/error-handler.service';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class StorePayService {
  private appUrl = environment.apiEndpoint + '/api/';
  private spUrl = `${this.appUrl}storepay`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, private errorService: ErrorHandlerService) { }

  getSummary(): Observable<CardPay[]> {
    const url =`${this.spUrl}/getsummary`;
    return this.http.get<CardPay[]>(url).pipe(
      catchError(this.errorService.handleError<CardPay[]>('getsummary')));
  }

  getStorePays(cardId: number): Observable<ViewStorePay[]> {
    const url =`${this.spUrl}/getstorepays/${cardId}`;
    return this.http.get<ViewStorePay[]>(url).pipe(
      catchError(this.errorService.handleError<ViewStorePay[]>(`getStorePays cardId=${cardId}`))
    );
  }

  getCardList(): Observable<CardItem[]> {
    const url =`${this.appUrl}card/getcardlist`;
    return this.http.get<CardItem[]>(url).pipe(
      catchError(this.errorService.handleError<CardItem[]>(' getCardList'))
    );
  }

  getStoreList(): Observable<StoreItem[]> {
    const url =`${this.appUrl}store/getstorelist`;
    return this.http.get<StoreItem[]>(url).pipe(
      catchError(this.errorService.handleError<StoreItem[]>('getStoreList'))
    );
  }

  getStorePay(id: number): Observable<StorePay> {
    const url = `${this.spUrl}/${id}`;
    return this.http.get<StorePay>(url).pipe(
      catchError(this.errorService.handleError<StorePay>(`getStore id=${id}`))
    );
  }

  addStorePay (storePay: StorePay): Observable<number> {
    const url =`${this.spUrl}`;
    return this.http.post<number>(url, storePay, this.httpOptions).pipe(
      catchError(this.errorService.handleError<number>('addStorePay'))
    );
  }

  updateStorePay (storePay: StorePay): Observable<any> {
    const id = storePay.id;
    const url = `${this.spUrl}/${id}`;
      return this.http.put(url, storePay, this.httpOptions).pipe(    
      catchError(this.errorService.handleError<any>('updateStorePay'))
    );
  }

  getCardExtendedList(): Observable<CardItem[]> {
    const url =`${this.appUrl}card/getcardextendedlist`;
    return this.http.get<CardItem[]>(url).pipe(    
      catchError(this.errorService.handleError<CardItem[]>('getCardExtendedList'))
    );
  }


  addClosing (closing: Closing): Observable<number> {
    const url =`${this.appUrl}closing`;
    return this.http.post<number>(url, closing, this.httpOptions).pipe(
      catchError(this.errorService.handleError<number>('addClosing'))
    );
  }	

  getStorePayList(cardId: number, filter = '', sortBy = 'Id', sortOrder = 'desc',
    pageNumber = 0, pageSize = 10): Observable<StorePayView[]> {

    const url =`${this.spUrl}/getstorepaylist`;
    return this.http.get<StorePayView[]>(url,
      {
        params: new HttpParams()
        .set('cardId', cardId.toString())
        .set('filter', filter)
        .set('sortBy', sortBy)        
        .set('sortOrder', sortOrder)
        .set('pageNumber', (pageNumber + 1).toString())
        .set('pageSize', pageSize.toString())
      }).pipe(
          map(res =>  res),
          catchError(this.errorService.handleError<StorePayView[]>(`getStorePayList cardId=${cardId}`))
      );   
  }

  getCardPay(cardId: number): Observable<CardPay> {
    const url = `${this.spUrl}/getcardpay/${cardId}`;
    return this.http.get<CardPay>(url).pipe(
      catchError(this.errorService.handleError<CardPay>(`getCardPay cardId=${cardId}`))
    );
  }

  
  getStorePaysByClosing(closingId: number): Observable<ViewStorePay[]> {
    const url =`${this.spUrl}/getstorepaysbyclosing/${closingId}`;
    return this.http.get<ViewStorePay[]>(url).pipe(
      catchError(this.errorService.handleError<ViewStorePay[]>(`getStorePaysByClosing closingId=${closingId}`))
    );
  } 
  
  getArchiveList(cardId: number, filter = '', sortBy = 'Id', sortOrder = 'desc',
    pageNumber = 0, pageSize = 10): Observable<ArchiveListView> {

    const url =`${this.spUrl}/getarchivelist`;

    return this.http.get<ArchiveListView>(url,
      {
        params: new HttpParams()
        .set('cardId', cardId.toString())
        .set('filter', filter)
        .set('sortBy', sortBy)        
        .set('sortOrder', sortOrder)
        .set('pageNumber', (pageNumber + 1).toString())
        .set('pageSize', pageSize.toString())
      }).pipe(
          map(res =>  res),
          catchError(this.errorService.handleError<ArchiveListView>(`getArchiveList cardId=${cardId}`))
      );   
  }

  getClosingList(cardId: number, sortBy = 'Id', sortOrder = 'desc',
    pageNumber = 0, pageSize = 10): Observable<ClosingView> {

    const url =`${this.appUrl}closing/getclosinglist`;

    return this.http.get<ClosingView>(url,
      {
        params: new HttpParams()
        .set('cardId', cardId.toString())
        .set('sortBy', sortBy)        
        .set('sortOrder', sortOrder)
        .set('pageNumber', (pageNumber + 1).toString())
        .set('pageSize', pageSize.toString())
      }).pipe(
          map(res =>  res),
          catchError(this.errorService.handleError<ClosingView>(`getClosingList cardId=${cardId}`))
      );   
  }

  getClosingPaysList(closingId: number, sortBy = 'Id', sortOrder = 'desc',
    pageNumber = 0, pageSize = 10): Observable<ClosingPayListView> {

    const url =`${this.appUrl}storepay/getstorepaysbyclosing`;

    return this.http.get<ClosingPayListView>(url,
      {
        params: new HttpParams()
        .set('closingId', closingId.toString())
        .set('sortBy', sortBy)        
        .set('sortOrder', sortOrder)
        .set('pageNumber', (pageNumber + 1).toString())
        .set('pageSize', pageSize.toString())
      }).pipe(
          map(res =>  res),
          catchError(this.errorService.handleError<ClosingPayListView>(`getClosingPayList closingId=${closingId}`))
      );   
  }  

  getClosingView(closingId: number): Observable<ClosingListData> {
    const url =`${this.appUrl}closing/getclosingview/${closingId}`;
    return this.http.get<ClosingListData>(url).pipe(
      catchError(this.errorService.handleError<ClosingListData>(`getClosingView closingId=${closingId}`))
    );
  } 

  getNextClosingNumber(cardId: number): any {
     const url = `${this.appUrl}closing/getnextclosingnumber/${cardId}`;

    return this.http.get(url, {responseType: 'text'}).pipe(
      catchError(this.errorService.handleError<any>(`getNextClosingNumber cardId=${cardId}`))
    );
  }

}
