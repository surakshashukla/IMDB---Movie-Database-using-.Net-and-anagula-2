"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var router_1 = require('@angular/router');
var movie_service_1 = require('../movie/movie.service');
var MovieListComponent = (function () {
    function MovieListComponent(router, _route, _movieService) {
        this.router = router;
        this._route = _route;
        this._movieService = _movieService;
    }
    MovieListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.title = "Movie List";
        this._route.params.subscribe(function (params) {
            if (!isNaN(params['id'])) {
                _this._movieService.getMovieListByCategory(params['id']).subscribe(function (_movieList) {
                    _this.movieList = _movieList;
                });
                _this._movieService.getMovieCategoryName(params['id']).subscribe(function (_title) {
                    _this.title = _title;
                });
                console.log(_this.title);
            }
            else {
                _this._movieService.getMoviesByKey(params['id']).subscribe(function (_movieList) {
                    _this.movieList = _movieList;
                });
                _this.title = "Search List";
            }
        });
    };
    MovieListComponent = __decorate([
        core_1.Component({
            templateUrl: './movieList.component.html'
        }), 
        __metadata('design:paramtypes', [router_1.Router, router_1.ActivatedRoute, movie_service_1.MovieService])
    ], MovieListComponent);
    return MovieListComponent;
}());
exports.MovieListComponent = MovieListComponent;
//# sourceMappingURL=movieList.component.js.map