/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { IssueTransactionComponent } from './issue-transaction.component';

let component: IssueTransactionComponent;
let fixture: ComponentFixture<IssueTransactionComponent>;

describe('issue-transaction component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ IssueTransactionComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(IssueTransactionComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});