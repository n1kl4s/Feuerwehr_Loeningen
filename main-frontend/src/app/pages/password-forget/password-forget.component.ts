import { Component, OnInit, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-password-forget',
  templateUrl: './password-forget.component.html',
  styleUrls: ['./password-forget.component.css']
})
export class PasswordForgetComponent implements OnInit, OnDestroy {

  ngOnDestroy(): void {
    document.body.classList.remove('bg-account-pages');
    document.body.classList.remove('py-4');
    document.body.classList.remove('py-sm-0');
  }

  constructor() { }

  ngOnInit() {

    document.body.classList.add('bg-account-pages');
    document.body.classList.add('py-4');
    document.body.classList.add('py-sm-0');

}

}
