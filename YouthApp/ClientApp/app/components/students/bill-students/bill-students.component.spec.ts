/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { BillStudentsComponent } from './bill-students.component';

let component: BillStudentsComponent;
let fixture: ComponentFixture<BillStudentsComponent>;

describe('bill-students component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ BillStudentsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(BillStudentsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});