import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    encapsulation: ViewEncapsulation.None,
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

    myStyle: object = {};
    myParams: object = {};
    width = 100;
    height = 100;

    closeResult: string;

    id = 'JlvxDa7Sges';
    playerVars = {
        cc_lang_pref: 'en'
    };

    private player;
    private ytEvent;

    constructor(private modalService: NgbModal) { }


    onStateChange(event) {
        this.ytEvent = event.data;
    }
    savePlayer(player) {
        this.player = player;
    }
    playVideo() {
        this.player.playVideo();
    }
    pauseVideo() {
        this.player.pauseVideo();
    }
    openWindowCustomClass(content) {
        this.modalService.open(content, { windowClass: 'dark-modal', size: 'lg' });
    }

    ngOnInit() {

        this.myStyle = {
            position: 'absolute',
            width: '100%',
            height: '100%',
            'z-index': 11,
            top: 0,
            left: 0,
            right: 0,
            bottom: 0,
        };

        this.myParams = {
            particles: {
                number: {
                    value: 80,
                },
                color: {
                    value: '#ffffff'
                },
                shape: {
                    type: 'circle',
                    stroke: {
                        width: 2,
                        color: '#fff'
                    },
                    anim: {
                        enable: true,
                        speed: 10
                    }
                },
            }
        };
    }
}
