import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from '../movie/movie.service';

@Component({
    templateUrl: './details.component.html'
})

export class DetailsComponent implements OnInit{
    title: string;
    public movie: any;
    constructor(private _route: ActivatedRoute, private _movieService: MovieService) { }

    ngOnInit() {
        this.title = "Movie List";

        let id = this._route.snapshot.params['id'];

        if (id) {
            this._movieService.getMovie(id).subscribe(_movie => {
                this.movie = _movie; this.title = _movie.name;
            });
        }
    }
}