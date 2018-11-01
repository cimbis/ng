import { NgModule } from '@angular/core';
import {
    Routes,
    RouterModule
} from '@angular/router';

import { HomeComponent } from './home/home.component';
import { GraphComponent } from './graph/graph.component';
import { ListComponent } from './list/list.component';
import { MessagesComponent } from './messages/messages.component';

const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'graph', component: GraphComponent },
    { path: 'list', component: ListComponent },
    { path: 'messages', component: MessagesComponent },
];

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule {

}
