import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HandlerComponent } from './components/handler/handler.component';

const routes: Routes = [
    { path: 'handler', component: HandlerComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
