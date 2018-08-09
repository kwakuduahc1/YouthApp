/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { DebtorsComponent } from './debtors.component';

let component: DebtorsComponent;
let fixture: ComponentFixture<DebtorsComponent>;

describe('debtors component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ DebtorsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(DebtorsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});