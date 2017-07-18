import { NgModule } from '@angular/core';
import { MovieRoutingModule, routedComponents } from './movie-routing.module';
import { CommonModule } from '@angular/common';

@NgModule({
    imports: [CommonModule, MovieRoutingModule],
    declarations: [routedComponents],
})


export class MovieModule {

}