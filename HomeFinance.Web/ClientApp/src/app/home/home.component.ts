import { Component, OnInit } from '@angular/core';

//import { CardPay } from '../Models/card-pay.model'; 
import { StorePayService } from '../services/store-pay.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  //sums: CardPay[];
  displayedColumns = ["id", "cardName", "numOfPays", "total", "activeTotal"];
  dataSource  = [];

  constructor(private storePayService: StorePayService) { }

  ngOnInit() {
    this.getSummary();
  }

  getSummary(): void {
    this.storePayService.getSummary()
    .subscribe(sums => this.dataSource = sums);
  }

}
