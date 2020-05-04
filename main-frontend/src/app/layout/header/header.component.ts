import { Component, Injectable, OnInit, HostListener } from '@angular/core';

@Injectable()
@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})

export class HeaderComponent {
    isNavbarCollapsed = true;

    @HostListener('window:scroll', ['$event'])
    onWindowScroll(event: Event) {
        const element = document.querySelector('.navbar');
        if (window.pageYOffset > element.clientHeight) {
            element.classList.remove('bg-nav');
            element.classList.add('bg-nav-inverse');
        }
        else {
            element.classList.remove('bg-nav-inverse');
            element.classList.add('bg-nav');
        }
    }
}



