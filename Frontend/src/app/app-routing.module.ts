import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HandlerComponent } from './components/handler/handler.component';
import { DepartmentListComponent } from './components/department/department-list/department-list.component';
import { DepartmentFormComponent } from './components/department/department-form/department-form.component';

const routes: Routes = [
    { path: 'handler', component: HandlerComponent },

    { path: 'department', component: DepartmentListComponent },

        { path: 'department/new', component: DepartmentFormComponent },

        { path: 'department/:id', component: DepartmentFormComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
