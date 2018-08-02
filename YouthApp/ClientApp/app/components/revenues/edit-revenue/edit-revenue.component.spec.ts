/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { EditRevenueComponent } from './edit-revenue.component';

let component: EditRevenueComponent;
let fixture: ComponentFixture<EditRevenueComponent>;

describe('edit-revenue component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ EditRevenueComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(EditRevenueComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});