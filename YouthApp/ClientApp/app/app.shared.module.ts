import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ChartsModule } from 'ng2-charts';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { BillItemHttpService } from './http/bill-items/bill-item.service';
import { AddBillItemComponent } from './components/bill-items/add-bill-item/add-bill-item.component';
import { EditItemComponent } from './components/bill-items/edit-item/edit-item.component';
import { BillItemsResolver } from './resolvers/bill-items/ListResolver';
import { FindItemResolver } from './resolvers/bill-items/FindResolver';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        AddBillItemComponent,
        EditItemComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        ChartsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'bill-items', component: AddBillItemComponent, resolve: { items: BillItemsResolver } },
            { path: 'edit-bill-item/:id', component: EditItemComponent, resolve: { item: FindItemResolver } },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        BillItemHttpService,
        BillItemsResolver,
        FindItemResolver
    ]
})
export class AppModuleShared {
}
