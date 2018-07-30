/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { EditClassComponent } from './edit-class.component';

let component: EditClassComponent;
let fixture: ComponentFixture<EditClassComponent>;

describe('edit-class component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ EditClassComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(EditClassComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});