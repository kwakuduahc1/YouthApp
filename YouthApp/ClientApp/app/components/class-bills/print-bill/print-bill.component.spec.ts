/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { PrintBillComponent } from './print-bill.component';

let component: PrintBillComponent;
let fixture: ComponentFixture<PrintBillComponent>;

describe('print-bill component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ PrintBillComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(PrintBillComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});