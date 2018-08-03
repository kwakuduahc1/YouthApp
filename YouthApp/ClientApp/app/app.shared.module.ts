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
import { StudentPaymentsComponent } from './components/students/payments/student-payments/student-payments.component';
import { StudentPaymentsHttpService } from './http/students/payments-http-service';
import { PrintProviderService } from './providers/print-provider.service';
import { PaymentSummaryResolver } from './resolvers/payments/PaySummaryResolver';
import { PaySummaryComponent } from './components/dashboard/pay-summary/pay-summary.component';
import { DebtorsResolver } from './resolvers/payments/DebtorsResolvery';
import { TopDebtorsComponent } from './components/dashboard/top-debtors/top-debtors.component';
import { RevenueHttpService } from './http/revenues/revenues-http-service';
import { RevenueListResolver } from './resolvers/revenues/RevenueListResolver';
import { FindRevenueResolver } from './resolvers/revenues/FindRevenueResolver';
import { AddRevenueComponent } from './components/revenues/add-revenue/add-revenue.component';
import { EditRevenueComponent } from './components/revenues/edit-revenue/edit-revenue.component';
import { YearGroupsResolver } from './resolvers/transactions/YearGroupsResolver';
import { IssueTransactionComponent } from './components/transactions/issue-transaction/issue-transaction.component';
import { ReceiveTransactionComponent } from './components/transactions/receive-transaction/receive-transaction.component';
import { EditTransactionComponent } from './components/transactions/edit-transaction/edit-transaction.component';
import { TransactionItemsHttpService } from './http/tran-items/tran-items-http-service';
import { TransactionsHttpService } from './http/transactions/payments-http-service';
import { TransactionsResolver } from './resolvers/transactions/TransactionsResolver';
import { FindTransactionResolver } from './resolvers/transactions/FindTransactionResolver';
import { FindTransactionItemResolver } from './resolvers/transaction-item/find-tran-item-resolver';
import { TransactionItemsResolver } from './resolvers/transaction-item/tran-items-resolver';

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
        BillStudentsComponent,
        StudentPaymentsComponent,
        PaySummaryComponent,
        TopDebtorsComponent,
        AddRevenueComponent,
        EditRevenueComponent,
        IssueTransactionComponent,
        ReceiveTransactionComponent,
        EditTransactionComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        ChartsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent, resolve: { 'payments': PaymentSummaryResolver, debtors: DebtorsResolver } },
            { path: 'bill-items', component: AddBillItemComponent, resolve: { items: BillItemsResolver } },
            { path: 'edit-bill-item/:id', component: EditItemComponent, resolve: { item: FindItemResolver } },
            { path: 'classes', component: AddClassComponent, resolve: { classes: ClassesListResolver } },
            { path: 'edit-class/:id', component: EditClassComponent, resolve: { 'class': FindClassResolver } },
            { path: 'class-bills', component: ClassBillComponent, resolve: { 'years': YearGroupsResolver, 'items': BillItemsResolver } },
            { path: 'view-class-bill/:id', component: ViewBillComponent, resolve: { 'class': FindClassResolver, 'years': YearGroupsResolver } },
            { path: 'add-revenue', component: AddRevenueComponent, resolve: { 'revenues': RevenueListResolver } },
            { path: 'edit-revenue/:id', component: EditRevenueComponent, resolve: { 'revenue': FindRevenueResolver } },
            { path: 'bill-student/:id', component: BillStudentsComponent, resolve: { students: StudentsResolver } },
            { path: 'student-payments', component: StudentPaymentsComponent, resolve: { classes: ClassesListResolver } },
            { path: 'issue-transaction', component: IssueTransactionComponent, resolve: { 'items': TransactionItemsResolver,types: } },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        BillItemHttpService,
        BillItemsResolver,
        ClassBillHttpService,
        ClassesHttpService,
        ClassesListResolver,
        DebtorsResolver,
        FindClassResolver,
        FindItemResolver,
        FindRevenueResolver,
        FindTransactionItemResolver,
        FindTransactionResolver,
        HelperHttpService,
        PaymentSummaryResolver,
        PrintProviderService,
        RevenueHttpService,
        RevenueListResolver,
        StudentPaymentsHttpService,
        StudentsHttpService,
        StudentsResolver,
        TermsResolver,
        TransactionItemsHttpService,
        TransactionItemsHttpService,
        TransactionsHttpService,
        TransactionsResolver,
        YearGroupsResolver,
    ]
})
export class AppModuleShared {
}
