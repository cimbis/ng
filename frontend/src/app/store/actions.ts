import { Action } from '@ngrx/store';
import { DataPoint } from '../app.types';

export const ADD_DATA_POINT = 'app/ADD_DATA_POINT';
export const REMOVE_DATA_POINT = 'app/REMOVE_DATA_POINT';
export const UPDATE_DATA_POINT = 'app/UPDATE_DATA_POINT';

export class AddDataPoint implements Action {
    readonly type = ADD_DATA_POINT;

    constructor(public payload: DataPoint) {
    }
}

export class RemoveDataPoint implements Action {
    readonly type = REMOVE_DATA_POINT;

    constructor(public payload: DataPoint) {
    }
}

export class UpdateDataPoint implements Action {
    readonly type = UPDATE_DATA_POINT;

    constructor(public payload: DataPoint) {
    }
}


export type Actions = AddDataPoint
                    | RemoveDataPoint
                    | UpdateDataPoint;
