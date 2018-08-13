/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { EditTranItemComponent } from './edit-tran-item.component';

let component: EditTranItemComponent;
let fixture: ComponentFixture<EditTranItemComponent>;

describe('edit-tran-item component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ EditTranItemComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(EditTranItemComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});