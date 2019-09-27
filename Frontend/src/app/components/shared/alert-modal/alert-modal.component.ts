import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-alert-modal',
    templateUrl: './alert-modal.component.html',
    styleUrls: ['./alert-modal.component.css']
})
export class AlertModalComponent implements OnInit {
    @Input() title: string;
    @Input() message: string;
    @Input() alert: boolean;
    @Input() error: boolean;

    constructor(public activeModal: NgbActiveModal) {}

    ngOnInit() {
        if (!this.title) {
            if (this.error) {
                this.title = 'Error';
            } else if (this.alert) {
                this.title = 'Alert';
            } else {
                this.title = 'Message';
            }
        }
    }
}
