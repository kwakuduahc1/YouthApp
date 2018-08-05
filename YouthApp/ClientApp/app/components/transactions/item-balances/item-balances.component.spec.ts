/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ItemBalancesComponent } from './item-balances.component';

let component: ItemBalancesComponent;
let fixture: ComponentFixture<ItemBalancesComponent>;

describe('item-balances component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ItemBalancesComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ItemBalancesComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});