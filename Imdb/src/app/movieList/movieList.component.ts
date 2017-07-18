import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { MovieService } from '../movie/movie.service';

@Component({
    templateUrl: './movieList.component.html'
})

export class MovieListComponent implements OnInit {

    public movieList: any;
    title: string;
    constructor(private router: Router, private _route: ActivatedRoute, private _movieService: MovieService) { }

    ngOnInit() {
        this.title = "Movie List";

        this._route.params.subscribe((params: Params) => {
            if (!isNaN(params['id'])) {
                this._movieService.getMovieListByCategory(params['id']).subscribe(_movieList => {
                    this.movieList = _movieList;
                });

                this._movieService.getMovieCategoryName(params['id']).subscribe(_title => {
                    this.title = _title;
                });

                console.log(this.title);
            } else {

                this._movieService.getMoviesByKey(params['id']).subscribe(_movieList => {
                    this.movieList = _movieList; 
                });

                this.title = "Search List";
            }

        });

    }

}
