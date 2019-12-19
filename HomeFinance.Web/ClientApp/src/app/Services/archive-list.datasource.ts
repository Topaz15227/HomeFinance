import {CollectionViewer, DataSource} from "@angular/cdk/collections";
import {Observable, BehaviorSubject, of} from "rxjs";
import {catchError, finalize} from "rxjs/operators";

import { ArchiveListView, ArchiveListData} from '../models/archive-list-view.model';
import { StorePayService } from '../services/store-pay.service';

export class ArchiveListDataSource implements DataSource<ArchiveListData> {

    private archiveListSubject = new BehaviorSubject<ArchiveListData[]>([]);

    private loadingSubject = new BehaviorSubject<boolean>(false);

    public rowCount: number;

    public loading$ = this.loadingSubject.asObservable();

    constructor(private storePayService: StorePayService) {
    }

    loadArchiveList(cardId:number,
                filter:string ='',
                sortDirection:string = 'desc',
                pageIndex:number = 0,
                pageSize:number = 10) {

        this.rowCount = 0;

        this.loadingSubject.next(true);

        this.storePayService.getArchiveList(cardId, filter, 'Id', sortDirection,
            pageIndex, pageSize).pipe(
                catchError(() => of()),
                finalize(() => this.loadingSubject.next(false))
            )
            .subscribe(res => {
                if(res){
                    var data = res as ArchiveListView;
                    this.rowCount = data.rowCount;               
                    this.archiveListSubject.next(data.archiveListData as ArchiveListData[]);
                }
            } 
        )    
    }

    connect(collectionViewer: CollectionViewer): Observable<ArchiveListData[]> {
        return this.archiveListSubject.asObservable();
    }

    disconnect(collectionViewer: CollectionViewer): void {
        this.archiveListSubject.complete();
        this.loadingSubject.complete();
    }

}
