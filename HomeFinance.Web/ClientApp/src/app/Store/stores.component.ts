import { Component, OnInit, ViewChild} from '@angular/core';
import { MatPaginator, MatTableDataSource, MatSort  } from '@angular/material';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { Store } from '../models/store.model'; 
import { StoreService } from '../services/store.service';


@Component({
  selector: 'app-stores',
  templateUrl: './stores.component.html',
  styleUrls: ['./stores.component.css']
})

export class StoresComponent implements OnInit {
  public storeForm: FormGroup;
  displayedColumns = ["id", "storeName", "active"];
  store: Store;
  showEdit: Boolean;
  dataSource: any;
  waiting: Boolean;

   @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
   @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private storeService: StoreService) { }

  ngOnInit() {
    this.loadData();
  }

  loadData(){
    this.store = null;   
    this.getStores();
    this.showEdit = false;    
  }

  getStores(): void {
    this.waiting = true;
    this.storeService.getAllStores()
    .subscribe(stores => { this.setDataSource(stores); this.waiting = false; });
  }

  //client paging & sorting
  setDataSource(stores){
    this.dataSource = new MatTableDataSource(stores);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  viewEdit(store){
    this.store = store;
    this.setForm(this.store);
    this.showEdit = true;
  }

  createStore(){
    this.store = new Store();
    this.store.id=0;
    this.store.storeName="";
    this.store.active=true;
    this.setForm(this.store);
    this.showEdit = true;
  }

  setForm(store){
    this.storeForm= new FormGroup(
      {
        storeName: new FormControl(store.storeName, [Validators.required, Validators.maxLength(30)]),
        active: new FormControl(store.active)
      }
    );
  }

  saveStore(storeFormValue): void {
    if(this.storeForm.valid){
      this.waiting = true;

      this.store.storeName=storeFormValue.storeName;
      this.store.active=storeFormValue.active;

      if(this.store.id==0){
        this.storeService.addStore(this.store)
          .subscribe(() => this.closeUpdate());
      }
      else {
        this.storeService.updateStore(this.store)
          .subscribe(() => this.closeUpdate());
      }      
    }
  }

  closeUpdate(){
    this.loadData();
    this.waiting = false;
  }

  close(){
    this.showEdit = false;
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.storeForm.controls[controlName].hasError(errorName);
  }
  
}
