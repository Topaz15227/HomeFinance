import { Component, OnInit, Input, AfterViewInit, ElementRef, ViewChild  } from '@angular/core';
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { tap } from 'rxjs/operators';
import { merge, fromEvent } from "rxjs";
import { MatDatepickerInputEvent } from '@angular/material';

import { CardItem } from '../models/card-item.model';
import { StorePayView } from '../models/store-pay-view.model';  
import { StorePayService } from '../services/store-pay.service';
import { Closing } from '../models/closing.model';
import { StorePayDataSource } from '../services/store-pay.datasource';
import { CardPay } from '../models/card-pay.model'; 

@Component({
  selector: 'app-store-pays',
  templateUrl: './store-pays.component.html',
  styleUrls: ['./store-pays.component.css']
})
export class StorePaysComponent implements AfterViewInit,  OnInit {
  public closingForm: FormGroup;
  @Input() closing: Closing;
  cards: CardItem[];
  cardId: number;
  date: Date;
  cardPay: CardPay;
  dataSource: StorePayDataSource;
  displayedColumns = ["id", "payDate", "cardName", "storeName", "amount", "note", "active"]; 
  filter ='';
  public inProcess: Boolean;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private storePayService: StorePayService) { }

  ngOnInit() {
    this.cardId =0;

    this.getCardPay(); 
    this.getCardExtendedList();

    this.dataSource = new StorePayDataSource(this.storePayService);
    this.dataSource.loadStorePays(this.cardId, this.filter,  'desc', 0, 10); 

    this.loadStorePaysPage(); 
    
  }

  getCardExtendedList(): void {
    this.inProcess = true;

    this.storePayService.getCardExtendedList()
    .subscribe(cards => { this.cards = cards; this.inProcess = false} );
  }

  ngAfterViewInit() {

    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
        
    merge(this.sort.sortChange, this.paginator.page)
        .pipe(
            tap(() => this.loadStorePaysPage())
        )
        .subscribe();
  }

  getCardPay(): void{
    this.inProcess = true;

    this.storePayService.getCardPay(this.cardId)
      .subscribe(cardPay => { this.cardPay = cardPay; this.inProcess = false});
  }

  changeCard(id) {
    this.inProcess = true;
    this.cardId = id;
    this.getCardPay(); 

    if(id > 0){
      this.inProcess = true;

      this.storePayService.getNextClosingNumber(this.cardId).subscribe(num => this.setClosingForm(num));
    }

    this.dataSource.loadStorePays(this.cardId, this.filter,  'desc', 0, 10); 

    this.paginator.pageIndex=0;
  }

  setClosingForm(num){
    this.closing = new Closing();
    this.closing.id=0;
    this.closing.cardId=this.cardId;
    this.date=new Date();
    this.closing.closingDate = this.date;
    this.closing.closingName=num ? num.toString() : '';

    this.closingForm = new FormGroup(
    {
      closingName: new FormControl(this.closing.closingName, [Validators.required, Validators.maxLength(15)]) 
    });

    this.inProcess = false;
  }

  selectedDate(event: MatDatepickerInputEvent<Date>) {
    this.closing.closingDate = event.value;
  }

  closePays(closingFormValue){
    if(this.closingForm.valid){
      this.inProcess = true;

      this.closing.closingAmount = this.cardPay.activeTotal;
      this.closing.closingName = closingFormValue.closingName;

      this.storePayService.addClosing(this.closing)
      .subscribe(() => this.refresh());      
    }

  }

  refresh(){
    this.paginator.pageIndex = 0;
    this.getCardPay();
    this.loadStorePaysPage();
    this.inProcess = false;
  }

  loadStorePaysPage() {
    this.dataSource.loadStorePays(
      this.cardId, 
      this.filter,
      this.sort ? this.sort.direction : 'desc',
      this.paginator ? this.paginator.pageIndex : 0,
      this.paginator ? this.paginator.pageSize: 10);
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.closingForm.controls[controlName].hasError(errorName);
  }

}
