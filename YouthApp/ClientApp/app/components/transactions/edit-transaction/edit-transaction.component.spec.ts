/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { EditTransactionComponent } from './edit-transaction.component';

let component: EditTransactionComponent;
let fixture: ComponentFixture<EditTransactionComponent>;

describe('edit-transaction component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ EditTransactionComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(EditTransactionComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});