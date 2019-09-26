import { Component, OnInit } from '@angular/core';
import { Parcel } from 'src/app/model/parcel';
import { Person } from 'src/app/model/person';
import { HandlerService } from 'src/app/services/handler.service';
import { Department } from 'src/app/model/department';
import { Interval } from 'src/app/model/value-objects/interval';

@Component({
    selector: 'app-handler',
    templateUrl: './handler.component.html',
    styleUrls: ['./handler.component.css']
})
export class HandlerComponent implements OnInit {
    public parcel: Parcel;
    department: Department;

    constructor(private handlerService: HandlerService) {
        this.parcel = new Parcel();
    }

    ngOnInit() {}

    handleParcel() {
        this.handlerService.handleParcel(this.parcel).subscribe(
            (department: Department) => {
                this.department = department;
            },
            error => {
                alert(error);
            }
        );
    }

    intervalAsString(interval: Interval) {
        if (interval.min && interval.max) {
            return `${interval.min} to ${interval.max}`;
        } else if (interval.min) {
            return `from ${interval.min}`;
        } else if (interval.max) {
            return `up to ${interval.max}`;
        } else {
            return '';
        }
    }
}
