import {CollectionViewer, DataSource} from "@angular/cdk/collections";
import {Observable, BehaviorSubject, of} from "rxjs";
import {catchError, finalize} from "rxjs/operators";

import { ClosingPayListView, ClosingPayListData } from '../models/closing-pay-list-view.model';
import { StorePayService } from '../services/store-pay.service';

export class ClosingPayDataSource implements DataSource<ClosingPayListData> {

    private closingPaysSubject = new BehaviorSubject<ClosingPayListData[]>([]);

    private loadingSubject = new BehaviorSubject<boolean>(false);

    public rowCount: number;

    public loading$ = this.loadingSubject.asObservable();

    constructor(private storePayService: StorePayService) {
    }

    loadClosingPays(closingId:number,
        sortDirection:string = 'desc',
        pageIndex:number = 0,
        pageSize:number = 10) {

        this.rowCount = 0;

        this.loadingSubject.next(true);

        this.storePayService.getClosingPaysList(closingId, 'Id', sortDirection,
            pageIndex, pageSize).pipe(
                catchError(() => of()),
                finalize(() => this.loadingSubject.next(false))
            )
            .subscribe(res => {
                if(res){
                    var data = res as ClosingPayListView;
                    this.rowCount = data.rowCount;               
                    this.closingPaysSubject.next(data.closingPayListData as ClosingPayListData[]);                    
                }
            } 
        )    
    }

    connect(collectionViewer: CollectionViewer): Observable<ClosingPayListData[]> {
        return this.closingPaysSubject.asObservable();
    }

    disconnect(collectionViewer: CollectionViewer): void {
        this.closingPaysSubject.complete();
        this.loadingSubject.complete();
    }

}