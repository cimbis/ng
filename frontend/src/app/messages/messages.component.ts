import {
    Component,
    OnInit
} from '@angular/core';
import {
    FormControl,
    FormGroup
} from '@angular/forms';
import { DataPoint } from '../app.types';
import { AppState } from '../store/state';
import { Store } from '@ngrx/store';

class Message implements DataPoint {
    Id: string;
    Name: string;
    RecordedAt: Date;
    Value: number;

    constructor(name: string, value: number) {
        this.Id = Math.random().toString();
        this.RecordedAt = new Date();
        this.Name = name;
        this.Value = value;
    }

}

@Component({
    selector: 'app-messages',
    templateUrl: './messages.component.html',
    styleUrls: [ './messages.component.scss' ]
})
export class MessagesComponent implements OnInit {

    messages: DataPoint[];
    messageFormGroup: FormGroup;

    constructor(private store: Store<AppState>) {
        store
            .select('appStore')
            .subscribe((dps: DataPoint[]) => this.messages = dps);
    }

    ngOnInit() {

        this.messageFormGroup = new FormGroup({
            name: new FormControl(),
            value: new FormControl()
        });
    }

    postMessage() {

        // the redux action stuff and websocket magic
        this.messages.push(
            new Message(
                this.messageFormGroup.controls.name.value,
                this.messageFormGroup.controls.value.value
            )
        );

        this.messageFormGroup.controls.messageInput.reset();
    }
}
