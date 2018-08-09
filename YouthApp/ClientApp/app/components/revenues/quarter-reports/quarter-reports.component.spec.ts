/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { QuarterReportsComponent } from './quarter-reports.component';

let component: QuarterReportsComponent;
let fixture: ComponentFixture<QuarterReportsComponent>;

describe('quarter-reports component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ QuarterReportsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(QuarterReportsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});