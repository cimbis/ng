import * as AppActions from './actions';
import { DataPoint } from '../app.types';

const initialState: DataPoint[] = [
    {
        Id: 'random-string',
        Name: 'GOLD 123',
        RecordedAt: new Date(),
        Value: 500
    },
    {
        Id: '111-random-string',
        Name: 'GOLD 333',
        RecordedAt: new Date(),
        Value: 444
    },
    {
        Id: 'random-333-string',
        Name: 'GOLD 999',
        RecordedAt: new Date(),
        Value: 777
    }
];

function appReducer(state: DataPoint[] = initialState, action: AppActions.Actions) {
    switch (action.type) {

        case AppActions.ADD_DATA_POINT:
            return [
                ...state,
                action.payload
            ];

        case AppActions.REMOVE_DATA_POINT:
            return state.filter((dp): DataPoint => {
                    if (dp.Id !== action.payload.Id) {
                        return dp;
                    }
                }
            );

        case AppActions.UPDATE_DATA_POINT:
            return state.map((dp): DataPoint => {
                if (dp.Id === action.payload.Id) {
                    return action.payload;
                }
                return dp;
            });

        default:
            return state;
    }
}

export {
    appReducer
};
