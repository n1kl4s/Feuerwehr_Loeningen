import { Component, OnInit  } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  switch = 1;
  curYear = 0;

  constructor() {
  }

  ngOnInit() {
    this.curYear = new Date().getFullYear();
  }
}
