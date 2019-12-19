import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  public title: string;

  constructor(private titleService: Title) { }

  ngOnInit() {
    this.title ="Home Finance";
    this.titleService.setTitle("Home Finance");
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public setTitle( newTitle: string) {
    this.title = 'Home Finance' + ' - ' + (newTitle =='Home Finance' ? 'Summary' : newTitle);
    this.titleService.setTitle( newTitle );
  }

}
