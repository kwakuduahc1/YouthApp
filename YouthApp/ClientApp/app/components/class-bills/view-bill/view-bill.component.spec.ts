/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ViewBillComponent } from './view-bill.component';

let component: ViewBillComponent;
let fixture: ComponentFixture<ViewBillComponent>;

describe('view-bill component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ViewBillComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ViewBillComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});