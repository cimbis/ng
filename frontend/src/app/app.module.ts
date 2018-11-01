import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import {
    FormsModule,
    ReactiveFormsModule
} from '@angular/forms';

import { StoreModule } from '@ngrx/store';

import { ChartsModule } from 'ng2-charts';

import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';

import { appReducer } from './store/reducers';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { MessagesComponent } from './messages/messages.component';
import { HomeComponent } from './home/home.component';
import { ListComponent } from './list/list.component';
import { GraphComponent } from './graph/graph.component';


@NgModule({
    declarations: [
        AppComponent,
        MessagesComponent,
        HomeComponent,
        ListComponent,
        GraphComponent
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        ReactiveFormsModule,
        AppRoutingModule,

        StoreModule.forRoot({
            appStore: appReducer
        }),

        ChartsModule,
        MatButtonModule,
        MatCardModule,
        MatInputModule,
        MatTableModule
    ],
    providers: [],
    bootstrap: [ AppComponent ]
})
export class AppModule {
}
