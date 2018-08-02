/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { AddRevenueComponent } from './add-revenue.component';

let component: AddRevenueComponent;
let fixture: ComponentFixture<AddRevenueComponent>;

describe('add-revenue component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ AddRevenueComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(AddRevenueComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});