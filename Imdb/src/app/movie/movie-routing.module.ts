import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MovieComponent } from './movie.component';
import { MovieListComponent } from '../movieList/movieList.component';
import { DetailsComponent } from '../Details/details.component';

const routes: Routes = [
    {
        path: '',
        children: [
            { path: 'movie', component: MovieComponent },
            { path: 'movie/:id', component: MovieListComponent },
            { path: 'details/:id', component: DetailsComponent },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class MovieRoutingModule { }
export const routedComponents = [MovieComponent, MovieListComponent, DetailsComponent];