import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import {Observable} from 'rxjs';
import { catchError, map} from 'rxjs/operators';

import { Store } from '../models/store.model'; 
import { StoreListView } from '../models/store-list-view.model'; 
import { ErrorHandlerService } from '../services/error-handler.service';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class StoreService {
  private storeUrl =environment.apiEndpoint + '/api/store';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, private errorService: ErrorHandlerService) { }

  getStore(id: number): Observable<Store> {
    const url = `${this.storeUrl}/${id}`;
    return this.http.get<Store>(url).pipe(
      catchError(this.errorService.handleError<Store>(`getStore id=${id}`))
    );
  }

  addStore (store: Store): Observable<number> {
    return this.http.post<number>(this.storeUrl, store, this.httpOptions).pipe(
      catchError(this.errorService.handleError<number>('addStore'))
    );
  }

  updateStore (store: Store): Observable<any> {
    const id = store.id;
    const url = `${this.storeUrl}/${id}`;
      return this.http.put(url, store, this.httpOptions).pipe( 
//      tap(_ => this.log(`updated store id=${id}`)),     
        catchError(this.errorService.handleError<any>(`updateStore id=${id}`))
    );
  }

  //server side paging and sorting [not used now]
  getStores(sortBy = 'StoreName', sortOrder = 'asc',
    pageNumber = 0, pageSize = 10): Observable<StoreListView> {

    const url =`${this.storeUrl}/getstores`;

    return this.http.get<StoreListView>(url,
      {
        params: new HttpParams()
        .set('sortBy', sortBy)        
        .set('sortOrder', sortOrder)
        .set('pageNumber', (pageNumber + 1).toString())
        .set('pageSize', pageSize.toString())
      }).pipe(
          map(res =>  res),
          catchError(this.errorService.handleError<StoreListView>('getStoreList'))
      );   
  } 

  getAllStores(): Observable<Store[]> {
    const url = `${this.storeUrl}/getAllStores`;
    return this.http.get<Store[]>(url).pipe(
      catchError(this.errorService.handleError<Store[]>('getAllStores'))
    );
  }

}
