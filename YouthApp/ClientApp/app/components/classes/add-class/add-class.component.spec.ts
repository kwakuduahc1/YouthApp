/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { AddClassComponent } from './add-class.component';

let component: AddClassComponent;
let fixture: ComponentFixture<AddClassComponent>;

describe('add-class component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ AddClassComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(AddClassComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});