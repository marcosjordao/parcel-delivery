import { Injectable } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from '../components/shared/alert-modal/alert-modal.component';

@Injectable({
    providedIn: 'root'
})
export class MessageService {
    constructor(private modalService: NgbModal) {}

    public showError(message: string): void {
        this.showMessage(message, true, false);
    }

    public showAlert(message: string): void {
        this.showMessage(message, false, true);
    }

    public showMessage(message: string, error: boolean, alert: boolean): void {
        const modalRef = this.modalService.open(AlertModalComponent, {
            size: 'lg'
        });
        modalRef.componentInstance.title = 'Erro';
        modalRef.componentInstance.message = message;
        modalRef.componentInstance.error = error;
        modalRef.componentInstance.alert = alert;
    }
}
