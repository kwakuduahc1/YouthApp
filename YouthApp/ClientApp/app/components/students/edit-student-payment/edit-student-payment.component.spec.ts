/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { EditStudentPaymentComponent } from './edit-student-payment.component';

let component: EditStudentPaymentComponent;
let fixture: ComponentFixture<EditStudentPaymentComponent>;

describe('edit-student-payment component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ EditStudentPaymentComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(EditStudentPaymentComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});