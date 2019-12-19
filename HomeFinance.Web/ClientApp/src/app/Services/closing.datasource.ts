import {CollectionViewer, DataSource} from "@angular/cdk/collections";
import {Observable, BehaviorSubject, of} from "rxjs";
import {catchError, finalize} from "rxjs/operators";

import { ClosingView, ClosingListData } from '../models/closing-view.model';
import { StorePayService } from '../services/store-pay.service';

export class ClosingDataSource implements DataSource<ClosingListData> {

    private closingSubject = new BehaviorSubject<ClosingListData[]>([]);

    private loadingSubject = new BehaviorSubject<boolean>(false);

    public rowCount: number;

    public loading$ = this.loadingSubject.asObservable();

    constructor(private storePayService: StorePayService) {

    }

    loadClosing(cardId:number,
        filter='',
        sortDirection:string = 'desc',
        pageIndex:number = 0,
        pageSize:number = 10) {

        this.rowCount = 0;

        this.loadingSubject.next(true);

        this.storePayService.getClosingList(cardId, 'Id', sortDirection,
            pageIndex, pageSize).pipe(
                catchError(() => of()),
                finalize(() => this.loadingSubject.next(false))
            )
            .subscribe(res => {
                if(res){
                    var data = res as ClosingView;
                    this.rowCount = data.rowCount;               
                    this.closingSubject.next(data.closingListData as ClosingListData[]);                    
                }
            } 
        )    
    }

    connect(collectionViewer: CollectionViewer): Observable<ClosingListData[]> {
        return this.closingSubject.asObservable();
    }

    disconnect(collectionViewer: CollectionViewer): void {
        this.closingSubject.complete();
        this.loadingSubject.complete();
    }

}