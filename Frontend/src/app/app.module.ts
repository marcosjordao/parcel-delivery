import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HandlerComponent } from './components/handler/handler.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HttpClientModule } from '@angular/common/http';
import { DepartmentListComponent } from './components/department/department-list/department-list.component';
import { DepartmentFormComponent } from './components/department/department-form/department-form.component';
import { AlertModalComponent } from './components/shared/alert-modal/alert-modal.component';

@NgModule({
    declarations: [
        AppComponent,
        HandlerComponent,
        NavMenuComponent,
        DepartmentListComponent,
        DepartmentFormComponent,
        AlertModalComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
        NgbModule
    ],
    providers: [],
    entryComponents: [AlertModalComponent],
    bootstrap: [AppComponent]
})
export class AppModule {}
