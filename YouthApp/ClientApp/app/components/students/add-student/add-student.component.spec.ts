/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { AddStudentComponent } from './add-student.component';

let component: AddStudentComponent;
let fixture: ComponentFixture<AddStudentComponent>;

describe('add-student component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ AddStudentComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(AddStudentComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});