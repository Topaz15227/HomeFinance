import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { StorePaysComponent } from './StorePay/store-pays.component';
import { CardsComponent } from './Card/cards.component';
import { StoresComponent } from './Store/stores.component';
import { StoreEditComponent } from './Store/store-edit.component';
import { StorePayEditComponent } from './StorePay/store-pay-edit.component';
import { StorePaysByClosingComponent } from './Closing/store-pays-by-closing.component';
import { CardEditComponent } from './Card/card-edit.component';
import { ArchiveListComponent } from './Closing/archive-list.component';
import { ClosingListComponent } from './Closing/closing-list.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'cards', component: CardsComponent },
  { path: 'stores', component: StoresComponent },
  //{ path: 'storeedit/:id', component: StoreEditComponent },
  { path: 'storepays', component: StorePaysComponent },
  { path: 'storepayedit/:id', component: StorePayEditComponent },
  { path: 'closings', component: ClosingListComponent },
  { path: 'storepaysbyclosing/:id', component: StorePaysByClosingComponent },
  //{ path: 'cardedit/:id', component: CardEditComponent },
  { path: 'archivelist', component: ArchiveListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
