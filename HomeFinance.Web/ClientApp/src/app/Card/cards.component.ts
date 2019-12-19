import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { Card } from '../models/card.model'; 
import { CardService } from '../services/card.service';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {
  public cardForm: FormGroup;
  displayedColumns = ["id", "cardName", "cardDescription", "cardNumber", "closingName", "active"];
  dataSource  = [];
  card: Card;
  showEdit: Boolean;
  waiting: Boolean;

  constructor(private cardService: CardService) { }

  ngOnInit() {
    
    this.getCards();
  }

  getCards(): void {
    this.waiting = true;

    this.cardService.getCards()
    .subscribe(cards => { this.dataSource = cards; this.waiting = false; });
  }

  viewEdit(card){
    this.card = card;
    this.setForm(this.card);
    this.showEdit = true;
  }

  createCard(){
	  this.card = new Card();
	  this.card.id=0;
	  this.card.cardName = "";
	  this.card.cardDescription = "";
    this.card.cardNumber = "";
    this.card.closingName ="";
    this.card.active=true;
    this.setForm(this.card);
	  this.showEdit = true;
  }

  setForm(card){
    this.cardForm= new FormGroup(
      {
        cardName: new FormControl(card.cardName, [Validators.required, Validators.maxLength(15)]),
        cardDescription: new FormControl(card.cardDescription, [Validators.required, Validators.maxLength(25)]),
        cardNumber: new FormControl(card.cardNumber, [Validators.required, Validators.maxLength(20)]),
        closingName: new FormControl(card.closingName, [Validators.required, Validators.maxLength(3)]),
        active: new FormControl(card.active)
      }
    );
  }

  saveCard(cardFormValue): void {
    if(this.cardForm.valid){
      this.waiting = true;

      this.card.cardName=cardFormValue.cardName;
      this.card.cardDescription=cardFormValue.cardDescription;
      this.card.cardNumber=cardFormValue.cardNumber;
      this.card.closingName=cardFormValue.closingName;
      this.card.active=cardFormValue.active;

      if(this.card.id == 0){
        this.cardService.addCard(this.card)
        .subscribe(() => this.closeUpdate());
      }
      else {
        this.cardService.updateCard(this.card)
        .subscribe(() => this.closeUpdate());
      }
    }

 
  }
  closeUpdate(){
    this.getCards();
    this.showEdit = false;
    this.waiting = false;
  }

  close(){
    this.showEdit = false;
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.cardForm.controls[controlName].hasError(errorName);
  }

}