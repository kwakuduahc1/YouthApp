/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ReceiveTransactionComponent } from './receive-transaction.component';

let component: ReceiveTransactionComponent;
let fixture: ComponentFixture<ReceiveTransactionComponent>;

describe('receive-transaction component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ReceiveTransactionComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ReceiveTransactionComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});