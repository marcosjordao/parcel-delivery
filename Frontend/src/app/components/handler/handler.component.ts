import { Component, OnInit } from '@angular/core';
import { Parcel } from 'src/app/model/parcel';
import { HandlerService } from 'src/app/services/handler.service';
import { Department } from 'src/app/model/department';
import {
    Interval,
    intervalAsString
} from 'src/app/model/value-objects/interval';
import { MessageService } from 'src/app/services/message.service';

@Component({
    selector: 'app-handler',
    templateUrl: './handler.component.html',
    styleUrls: ['./handler.component.css']
})
export class HandlerComponent implements OnInit {
    public parcel: Parcel;
    department: Department;
    loading = false;

    constructor(
        private handlerService: HandlerService,
        private messageService: MessageService
    ) {
        this.parcel = new Parcel();
    }

    ngOnInit() {}

    handleParcel() {
        this.loading = true;
        this.handlerService.handleParcel(this.parcel).subscribe(
            (department: Department) => {
                this.department = department;
                this.loading = false;
            },
            error => {
                this.messageService.showError(error);
                this.loading = false;
            }
        );
    }

    getInterval(interval: Interval) {
        return intervalAsString(interval);
    }
}
