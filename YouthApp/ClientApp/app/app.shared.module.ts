import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ChartsModule } from 'ng2-charts';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { AddBillItemComponent } from './components/bill-items/add-bill-item/add-bill-item.component';
import { EditItemComponent } from './components/bill-items/edit-item/edit-item.component';
import { BillItemsResolver } from './resolvers/bill-items/ListResolver';
import { FindItemResolver } from './resolvers/bill-items/FindResolver';
import { BillItemHttpService } from './http/bill-items/bill-items-service';
import { AddClassComponent } from './components/classes/add-class/add-class.component';
import { ClassesListResolver } from './resolvers/classes/ClassesListResolver';
import { EditClassComponent } from './components/classes/edit-class/edit-class.component';
import { FindClassResolver } from './resolvers/classes/FindClassResolver';
import { ClassesHttpService } from './http/classes/classes-http-service';
import { ClassBillHttpService } from './http/class-bill/class-bill-http-service';
import { HelperHttpService } from './http/helper/helper-http-service';
import { TermsResolver } from './resolvers/class-bill/TermsResolver';
import { ClassBillComponent } from './components/class-bills/class-bill/class-bill.component';
import { EditBillComponent } from './components/class-bills/edit-bill/edit-bill.component';
import { ViewBillComponent } from './components/class-bills/view-bill/view-bill.component';
import { BillStudentsComponent } from './components/students/bill-students/bill-students.component';
import { StudentsResolver } from './resolvers/students/StudentsResolver';
import { StudentsHttpService } from './http/students/students-http-service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        AddBillItemComponent,
        EditItemComponent,
        AddClassComponent,
        EditClassComponent,
        ClassBillComponent,
        EditBillComponent,
        ViewBillComponent,
        BillStudentsComponent
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
            { path: 'classes', component: AddClassComponent, resolve: { classes: ClassesListResolver } },
            { path: 'edit-class/:id', component: EditClassComponent, resolve: { 'class': FindClassResolver } },
            { path: 'class-bills/:id', component: ClassBillComponent, resolve: { 'class': FindClassResolver, 'items': BillItemsResolver, 'terms': TermsResolver } },
            { path: 'view-class-bill/:id', component: ViewBillComponent, resolve: { 'class': FindClassResolver, 'terms': TermsResolver } },
            { path: 'bill-student/:id', component: BillStudentsComponent, resolve: { students: StudentsResolver } },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        BillItemHttpService,
        BillItemsResolver,
        FindItemResolver,
        ClassesHttpService,
        ClassesListResolver,
        FindClassResolver,
        ClassBillHttpService,
        HelperHttpService,
        TermsResolver,
        StudentsResolver,
        StudentsHttpService
    ]
})
export class AppModuleShared {
}
