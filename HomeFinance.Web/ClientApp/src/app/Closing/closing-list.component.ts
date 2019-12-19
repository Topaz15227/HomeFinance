import { Component, OnInit, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { tap } from 'rxjs/operators';
import { merge } from "rxjs";

import { ClosingDataSource } from '../services/closing.datasource';
import { StorePayService } from '../services/store-pay.service';
import { CardItem } from '../models/card-item.model';

@Component({
  selector: 'app-closing-list',
  templateUrl: './closing-list.component.html',
  styleUrls: ['./closing-list.component.css']
})
export class ClosingListComponent implements AfterViewInit, OnInit {

  cardId: number;
  cards: CardItem[];
  rowCount: number;
  dataSource: ClosingDataSource;
  displayedColumns = ["id", "cardName", "closingDate", "closingAmount", "closingName"];
 

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private storePayService: StorePayService) { }

  ngOnInit() {
    this.cardId =0;
    this.getCardExtendedList();
    this.dataSource = new ClosingDataSource(this.storePayService);
    this.dataSource.loadClosing(this.cardId, '',  'desc', 0, 10);
    this.getRowCount();   
  }

  ngAfterViewInit() {
  
   this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
        
    merge(this.sort.sortChange, this.paginator.page)
    .pipe(
      tap(() => {         
        this.loadClosingPage();      
      })
    )
    .subscribe();
 
  }

  loadClosingPage() {
    this.dataSource.loadClosing(
      this.cardId,
      '', 
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
    this.dataSource.loadClosing(this.cardId, '', 'desc', 0, 10);
    this.getRowCount();   

    this.paginator.pageIndex=0;
  }
}
