import {CollectionViewer, DataSource} from "@angular/cdk/collections";
import {Observable, BehaviorSubject, of} from "rxjs";
import { finalize} from "rxjs/operators";

import { StorePayView } from '../models/store-pay-view.model';
import { StorePayService } from '../services/store-pay.service';

export class StorePayDataSource implements DataSource<StorePayView> {

    private storePaysSubject = new BehaviorSubject<StorePayView[]>([]);

    private loadingSubject = new BehaviorSubject<boolean>(false);

    public loading$ = this.loadingSubject.asObservable();

    constructor(private storePayService: StorePayService) {}

    loadStorePays(cardId:number,
                filter:string ='',
                sortDirection:string = 'desc',
                pageIndex:number = 0,
                pageSize:number = 10) {

        this.loadingSubject.next(true);

        this.storePayService.getStorePayList(cardId, filter, 'PayDate', sortDirection,
            pageIndex, pageSize).pipe(

                finalize(() => this.loadingSubject.next(false))
            )
            .subscribe(pays => this.storePaysSubject.next(pays));

    }

    connect(collectionViewer: CollectionViewer): Observable<StorePayView[]> {
        return this.storePaysSubject.asObservable();
    }

    disconnect(collectionViewer: CollectionViewer): void {
        this.storePaysSubject.complete();
        this.loadingSubject.complete();
    }

}
