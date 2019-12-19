import { Component, OnInit, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { debounceTime, distinctUntilChanged, tap } from 'rxjs/operators';
import { merge, fromEvent } from "rxjs";

import { ArchiveListDataSource } from '../services/archive-list.datasource';
import { StorePayService } from '../services/store-pay.service';
import { CardItem } from '../models/card-item.model';

@Component({
  selector: 'app-archive-list',
  templateUrl: './archive-list.component.html',
  styleUrls: ['./archive-list.component.css']
})
export class ArchiveListComponent implements AfterViewInit, OnInit {

  cardId: number;
  cards: CardItem[];
  rowCount: number;
  dataSource: ArchiveListDataSource;
  displayedColumns = ["id", "payDate", "cardName", "storeName", "amount", "note", "closingDate", "closingId"];

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild('input', { static: false }) input: ElementRef;

  constructor(private storePayService: StorePayService) { }

  ngOnInit() {
    this.cardId =0;
    this.getCardExtendedList();
    this.dataSource = new ArchiveListDataSource(this.storePayService);
    this.dataSource.loadArchiveList(this.cardId, '',  'desc', 0, 10);
    this.getRowCount();   
  }

  ngAfterViewInit() {
  
    fromEvent(this.input.nativeElement,'keyup')
    .pipe(
        debounceTime(150),
        distinctUntilChanged(),
        tap(() => {      
            this.paginator.pageIndex = 0;
            this.loadArchiveListPage();
            this.getRowCount();           
        })
    )
    .subscribe();

    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
        
    merge(this.sort.sortChange, this.paginator.page)
    .pipe(
      tap(() => {         
        this.loadArchiveListPage();      
      })
    )
    .subscribe();
 
  }

  loadArchiveListPage() {
    this.dataSource.loadArchiveList(
      this.cardId, 
      this.input.nativeElement.value,
      this.sort.direction,
      this.paginator.pageIndex,
      this.paginator.pageSize);
  }

  getRowCount() {
    setTimeout(() => {
      this.rowCount =  this.dataSource.rowCount;

      if(this.rowCount == 0)
        this.getRowCount();  
    }, 1200/60);
  }

  getCardExtendedList(): void {
    this.storePayService.getCardExtendedList()
    .subscribe(cards => this.cards = cards);
  }

  changeCard(id) {
    this.cardId = id;
    this.dataSource.loadArchiveList(this.cardId, '',  'desc', 0, 10);
    this.getRowCount();   

    this.paginator.pageIndex=0;
  }

}