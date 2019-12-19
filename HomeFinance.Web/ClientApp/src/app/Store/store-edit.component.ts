//not used now
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Store } from '../models/store.model'; 
import { StoreService } from '../services/store.service';

@Component({
  selector: 'app-store-edit',
  templateUrl: './store-edit.component.html',
  styleUrls: ['./store-edit.component.css']
})
export class StoreEditComponent implements OnInit {
  @Input() store: Store;

  constructor(
    private route: ActivatedRoute,
    private storeService: StoreService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getStore();
  }

  getStore(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    if(id == 0){
      this.store = new Store();
      this.store.id=0;
      this.store.storeName="";
      this.store.active=true;
    }
    else {
      this.storeService.getStore(id)
        .subscribe(store => this.store = store);      
    }
  }

  goBack(): void {
    this.location.back();
  }

 save(): void {
   if(this.store.id==0){
    this.storeService.addStore(this.store)
      .subscribe(() => this.goBack());
   }
   else {
    this.storeService.updateStore(this.store)
      .subscribe(() => this.goBack());
   }

  }

}
