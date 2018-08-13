/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { TranItemsComponent } from './tran-items.component';

let component: TranItemsComponent;
let fixture: ComponentFixture<TranItemsComponent>;

describe('tran-items component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ TranItemsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(TranItemsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});