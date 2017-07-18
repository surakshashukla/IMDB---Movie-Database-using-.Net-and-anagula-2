import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from './movie.service';

@Component({
    templateUrl: './movie.component.html',
})

export class MovieComponent implements OnInit {
    public movieCatogories: any;
    public movieList: any;
    title: string;    

    constructor(private _route: ActivatedRoute, private router: Router, private _movieService: MovieService) { }

    ngOnInit() {
        this.title = "Movie Categories";
        
        this._movieService.getMovieCategories().subscribe(_movieCatogories => {
            this.movieCatogories = _movieCatogories;
        });
    }
}