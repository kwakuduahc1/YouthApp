/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { TopDebtorsComponent } from './top-debtors.component';

let component: TopDebtorsComponent;
let fixture: ComponentFixture<TopDebtorsComponent>;

describe('top-debtors component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ TopDebtorsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(TopDebtorsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});