import { Component, OnInit, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { tap } from 'rxjs/operators';
import { merge } from "rxjs";
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { ClosingListData } from '../models/closing-view.model';
import { StorePayService } from '../services/store-pay.service';
import { ClosingPayDataSource } from '../services/closing-pay.datasource';

@Component({
  selector: 'app-store-pays-by-closing',
  templateUrl: './store-pays-by-closing.component.html',
  styleUrls: ['./store-pays-by-closing.component.css']
})
export class StorePaysByClosingComponent implements AfterViewInit, OnInit {

  id: number;
  dataSource: ClosingPayDataSource;
  displayedColumns = ["id", "payDate", "storeName", "amount", "note"];
  rowCount: number;
  closing: ClosingListData;
  inProcess: Boolean;
  
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(
    private route: ActivatedRoute, 
    private storePayService: StorePayService,
    private location: Location) 
    { }

  ngOnInit() {
    this.id = +this.route.snapshot.paramMap.get('id');
    this.getClosingView();

    this.dataSource = new ClosingPayDataSource(this.storePayService);
    this.dataSource.loadClosingPays(this.id, 'desc', 0, 10);
    this.getRowCount();  	
	
  }
  
  ngAfterViewInit() {
  
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
        
    merge(this.sort.sortChange, this.paginator.page)
    .pipe(
      tap(() => {         
        this.loadArchiveListPage();      
      })
    )
    .subscribe();
  }

  getClosingView(){
    this.inProcess = true;
    this.storePayService.getClosingView(this.id)
      .subscribe(closing => {this.closing=closing; this.inProcess=false});
  }

  loadArchiveListPage() {
    this.dataSource.loadClosingPays(
      this.id, 
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
  
  goBackToList(): void {
    this.location.back();
  }
  
}