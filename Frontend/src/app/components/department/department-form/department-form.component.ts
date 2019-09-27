import { Component, OnInit } from '@angular/core';
import { Department } from 'src/app/model/department';
import { ActivatedRoute } from '@angular/router';
import { DepartmentService } from 'src/app/services/department.service';
import { MessageService } from 'src/app/services/message.service';
import { Location } from '@angular/common';

@Component({
    selector: 'app-department-form',
    templateUrl: './department-form.component.html',
    styleUrls: ['./department-form.component.css']
})
export class DepartmentFormComponent implements OnInit {
    department: Department;
    saving = false;

    constructor(
        private route: ActivatedRoute,
        private departmentService: DepartmentService,
        private messageService: MessageService,
        private location: Location
    ) {}

    ngOnInit() {
        this.getDepartment();
    }

    getDepartment(): void {
        const id = this.route.snapshot.paramMap.get('id');

        if (id !== null) {
            this.departmentService
                .getDepartment(id)
                .subscribe(
                    department => (this.department = department),
                    error => this.messageService.showError(error)
                );
        } else {
            this.department = new Department();
        }
    }

    goBack(): void {
        this.location.back();
    }

    save(): void {
        this.saving = true;
        if (this.department.id === undefined) {
            this.departmentService.addDepartment(this.department).subscribe(
                () => this.goBack(),
                error => {
                    this.messageService.showError(error);
                    this.saving = false;
                },
                () => (this.saving = false)
            );
        } else {
            this.departmentService.updateDepartment(this.department).subscribe(
                () => this.goBack(),
                error => {
                    this.messageService.showError(error);
                    this.saving = false;
                },
                () => (this.saving = false)
            );
        }
    }
}
