/// <reference path="../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { StudentPaymentsComponent } from './student-payments.component';

let component: StudentPaymentsComponent;
let fixture: ComponentFixture<StudentPaymentsComponent>;

describe('student-payments component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ StudentPaymentsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(StudentPaymentsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});