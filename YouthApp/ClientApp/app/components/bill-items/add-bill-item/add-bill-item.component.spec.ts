/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { AddBillItemComponent } from './add-bill-item.component';

let component: AddBillItemComponent;
let fixture: ComponentFixture<AddBillItemComponent>;

describe('add-bill-item component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ AddBillItemComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(AddBillItemComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});