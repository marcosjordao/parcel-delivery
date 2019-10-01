import { Component, OnInit } from '@angular/core';
import { Department } from 'src/app/model/department';
import { ActivatedRoute } from '@angular/router';
import { DepartmentService } from 'src/app/services/department.service';
import { MessageService } from 'src/app/services/message.service';
import { Location } from '@angular/common';
import { Interval } from 'src/app/model/value-objects/interval';
import { isNumber } from 'util';

@Component({
    selector: 'app-department-form',
    templateUrl: './department-form.component.html',
    styleUrls: ['./department-form.component.css']
})
export class DepartmentFormComponent implements OnInit {
    department: Department;
    weightCriteria = new Interval();
    valueCriteria = new Interval();
    saving = false;

    constructor(
        private route: ActivatedRoute,
        private departmentService: DepartmentService,
        private messageService: MessageService,
        private location: Location
    ) { }

    ngOnInit() {
        this.getDepartment();
    }

    getDepartment(): void {
        const id = this.route.snapshot.paramMap.get('id');

        if (id !== null) {
            this.departmentService
                .getDepartment(id)
                .subscribe(
                    department => {
                        this.department = department;
                        this.weightCriteria = this.department.weightCriteria ? this.department.weightCriteria : this.weightCriteria;
                        this.valueCriteria = this.department.valueCriteria ? this.department.valueCriteria : this.valueCriteria;
                    },
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
    updateWeightCriteria(): void {
        this.updateCriteria(this.weightCriteria);

        if (this.weightCriteria.min || this.weightCriteria.max) {
            this.department.weightCriteria = this.weightCriteria;
        } else {
            this.department.weightCriteria = undefined;
        }
    }

    updateValueCriteria(): void {
        this.updateCriteria(this.valueCriteria);

        if (this.valueCriteria.min || this.valueCriteria.max) {
            this.department.valueCriteria = this.valueCriteria;
        } else {
            this.department.valueCriteria = undefined;
        }
    }

    private updateCriteria(criteria: Interval): void {
        if (!criteria.min || isNaN(parseFloat(criteria.min.toLocaleString()))) {
            criteria.min = undefined;
        }
        if (!criteria.max || isNaN(parseFloat(criteria.max.toLocaleString()))) {
            criteria.max = undefined;
        }

    }
}
