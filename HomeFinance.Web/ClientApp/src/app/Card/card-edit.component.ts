// not used now
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Card } from '../models/card.model'; 
import { CardService } from '../services/card.service';

@Component({
  selector: 'app-card-edit',
  templateUrl: './card-edit.component.html',
  styleUrls: ['./card-edit.component.css']
})

export class CardEditComponent implements OnInit {

  @Input() card: Card;

  constructor(
    private route: ActivatedRoute,
    private cardService: CardService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getCard();
  }

  getCard(): void {
    const id = +this.route.snapshot.paramMap.get('id');

    if(id == 0) {
      this.card = new Card();
      this.card.id=0;
      this.card.cardName = "";
      this.card.cardDescription = "";
      this.card.cardNumber = "";
      this.card.active=true;
    }
    else {
      this.cardService.getCard(id)
        .subscribe(card => {
          this.card=card;
      });      
    }
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if(this.card.id == 0){
      this.cardService.addCard(this.card)
        .subscribe(() => this.goBack());
    }
    else {
      this.cardService.updateCard(this.card)
        .subscribe(() => this.goBack());
    }

  }

}
