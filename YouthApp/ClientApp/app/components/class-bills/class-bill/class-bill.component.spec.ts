/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ClassBillComponent } from './class-bill.component';

let component: ClassBillComponent;
let fixture: ComponentFixture<ClassBillComponent>;

describe('class-bill component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ClassBillComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ClassBillComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});