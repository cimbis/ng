import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from '../store/state';
import { DataPoint } from '../app.types';


@Component({
    selector: 'app-list',
    templateUrl: './list.component.html',
    styleUrls: [ './list.component.scss' ]
})
export class ListComponent implements OnInit {

    displayedColumns: string[];
    listData: DataPoint[];

    constructor(private store: Store<AppState>) {
        store
            .select('appStore')
            .subscribe((dps: DataPoint[]) => {
                this.listData = dps;
                this.displayedColumns = dps.length
                    ? Object.keys(dps[ 0 ]).filter(k => k !== 'Id')
                    : [ '' ];
            });
    }

    ngOnInit() {
    }

}
