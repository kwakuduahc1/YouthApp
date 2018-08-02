/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { PaySummaryComponent } from './pay-summary.component';

let component: PaySummaryComponent;
let fixture: ComponentFixture<PaySummaryComponent>;

describe('pay-summary component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ PaySummaryComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(PaySummaryComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});