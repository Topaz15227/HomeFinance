import { BrowserModule, Title } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import {MatInputModule, MatFormFieldModule, MatPaginatorModule, MatProgressSpinnerModule, MatSortModule, MatTableModule,
  MatDialog,  MatDialogRef } from '@angular/material';
import {MatNativeDateModule} from '@angular/material/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatIconModule} from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { StorePaysComponent } from './StorePay/store-pays.component';
import { CardsComponent } from './Card/cards.component';
import { StoresComponent } from './Store/stores.component';
import { StoreEditComponent } from './Store/store-edit.component';
import { StorePayEditComponent } from './StorePay/store-pay-edit.component';
import { StorePaysByClosingComponent } from './Closing/store-pays-by-closing.component';
import { CardEditComponent } from './Card/card-edit.component';
import { YesNoBooleanPipe } from './Shared/yes-no-boolean-pipe';
import { ArchiveListComponent } from './Closing/archive-list.component';
import { ClosingListComponent } from './Closing/closing-list.component';
import { ErrorDialogComponent } from './shared/error-dialog/error-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    CardsComponent,
    StoresComponent,
    StoreEditComponent,
    StorePaysComponent,
    StorePayEditComponent,
    StorePaysByClosingComponent,
    CardEditComponent,
    YesNoBooleanPipe,
    ArchiveListComponent,
    ClosingListComponent,
    ErrorDialogComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    MatInputModule, MatFormFieldModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatIconModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatProgressSpinnerModule,
    MatCardModule,
    ReactiveFormsModule
  ],
  entryComponents: [ 
    ErrorDialogComponent 
  ],
  providers: [DatePipe, Title],
  bootstrap: [AppComponent]
})
export class AppModule { }
