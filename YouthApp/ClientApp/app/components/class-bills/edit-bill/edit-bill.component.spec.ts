/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { EditBillComponent } from './edit-bill.component';

let component: EditBillComponent;
let fixture: ComponentFixture<EditBillComponent>;

describe('edit-bill component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ EditBillComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(EditBillComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});