import { Component } from '@angular/core';
//import { IStatuses } from '../../model/IStatuses';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    //statuses: IStatuses[];

    constructor(route: ActivatedRoute) {
        //this.statuses = route.snapshot.data['statuses'];
    }
}
