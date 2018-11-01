import {
    Component,
    OnInit
} from '@angular/core';
import { Store } from '@ngrx/store';

import { DataPoint } from '../app.types';
import { AppState } from '../store/state';

@Component({
    selector: 'app-graph',
    templateUrl: './graph.component.html',
    styleUrls: [ './graph.component.scss' ]
})
export class GraphComponent implements OnInit {

    dataPoints: DataPoint[];
    chartData: number[];
    chartLabels: string[];
    chartType: string = 'polarArea';

    constructor(private store: Store<AppState>) {
        store
            .select('appStore')
            .subscribe((dps: DataPoint[]) => this.dataPoints = dps);
    }

    ngOnInit() {
        this.getChartData();
        this.getChartLabels();
    }

    public getChartLabels(): void {
        this.chartLabels = this.dataPoints.map((dp: DataPoint) => {
            return dp.Name;
        });
    }

    public getChartData(): void {
        this.chartData = this.dataPoints.map((dp: DataPoint) => {
            return dp.Value;
        });
    }

    public chartClicked(e: any): void {
        console.log(e);
    }

    public chartHovered(e: any): void {
        console.log(e);
    }




}
