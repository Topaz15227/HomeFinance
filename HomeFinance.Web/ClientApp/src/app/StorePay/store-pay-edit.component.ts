import { Component, OnInit, Input} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material';

import { StorePay } from '../models/store-pay.model'; 
import { StorePayService } from '../services/store-pay.service';
import { CardItem } from '../models/card-item.model';
import { StoreItem } from '../models/store-item.model'; 

@Component({
  selector: 'app-store-pay-edit',
  templateUrl: './store-pay-edit.component.html',
  styleUrls: ['./store-pay-edit.component.css']
})
export class StorePayEditComponent implements OnInit {
  public payForm: FormGroup;  
  @Input() pay: StorePay;
  cards: CardItem[];
  stores: StoreItem[];
  date: Date;
  inProcess: Boolean;

  constructor(
    private route: ActivatedRoute,
    private storePayService: StorePayService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.inProcess=true;
    this.getStorePay();
    this.getCardList();
    this.getStoreList();
  }

  getStorePay(): void {
    const id = +this.route.snapshot.paramMap.get('id');

    if(id == 0) {
      this.pay = new StorePay();
      this.pay.id = 0;
      this.pay.cardId=1;
      this.pay.storeId=1;//8;
      this.date=new Date();
      this.pay.payDate=this.date;
     // this.pay.amount=0;
      this.pay.active=true;
      this.setForm(this.pay);      
    }
    else {
      this.storePayService.getStorePay(id)
        .subscribe(pay => {
          this.pay=pay;
          this.date=pay.payDate;
          this.setForm(this.pay);
        });      
    }

  }

  setForm(pay){
    this.payForm= new FormGroup(
      {
        amount: new FormControl(pay.amount, [Validators.required,  Validators.pattern(/^[+\-]?([0-9]+(?:[\.][0-9]*)?|\.[0-9]+)$/), this.notZero]),
        note: new FormControl(pay.note, [Validators.maxLength(40)]),
        active: new FormControl(pay.active)
      }
    );
    this.inProcess=false;
  }

  getCardList(): void {
    this.storePayService.getCardList()
    .subscribe(cards => this.cards = cards);
  }

  getStoreList(): void {
    this.storePayService.getStoreList()
    .subscribe(stores => this.stores = stores);
  }

  goBack(): void {
    this.location.back(); 
  }

  savePay(payFormValue): void {
    if(this.payForm.valid){
      this.pay.amount=payFormValue.amount;
      this.pay.note=payFormValue.note;
      this.pay.active=payFormValue.active;

      if(this.pay.id == 0){
        this.storePayService.addStorePay(this.pay)
          .subscribe(() => this.location.back());
      }
      else {
        this.storePayService.updateStorePay(this.pay)
          .subscribe(() => this.location.back());
      }     
    }

  }

  changeCard(id) {
    this.pay.cardId = id;
  }

  changeStore(id) {
    this.pay.storeId = id;
  }

  selectedDate(event: MatDatepickerInputEvent<Date>) {
    //console.log(`date: ${event.value}`);
    this.pay.payDate = event.value;
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.payForm.controls[controlName].hasError(errorName);
  }

  notZero(control: FormControl){
    return control.value != '0' ? null : {notZero: true}
  }

}
