import { Component, OnInit } from '@angular/core';
import { Department } from 'src/app/model/department';
import { DepartmentService } from 'src/app/services/department.service';
import { MessageService } from 'src/app/services/message.service';
import { Interval, intervalAsString } from 'src/app/model/value-objects/interval';

@Component({
    selector: 'app-department-list',
    templateUrl: './department-list.component.html',
    styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {
    departments: Department[];
    deleting: Department;

    constructor(
        private departmentService: DepartmentService,
        private messageService: MessageService
    ) {}

    ngOnInit() {
        this.getDepartments();
    }

    getDepartments(): void {
        this.departmentService
            .getDepartments()
            .subscribe(
                departments => (this.departments = departments),
                error => this.messageService.showError(error)
            );
    }

    delete(department: Department): void {
        this.deleting = department;
        this.departmentService.deleteDepartment(department).subscribe(
            () =>
                (this.departments = this.departments.filter(
                    h => h !== department
                )),
            error => {
                this.messageService.showError(error);
                this.deleting = null;
            },

            () => (this.deleting = null)
        );
    }

    getInterval(interval: Interval) {
        return intervalAsString(interval);
    }
}
