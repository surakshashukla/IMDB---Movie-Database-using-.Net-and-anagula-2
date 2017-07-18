import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class MovieService {

    private endpoint: string = '/api/movie/';

    constructor(private http: Http) { }

    getMovieCategoryName(id: string): Observable<any> {
        return this.http
            .get(this.endpoint + 'GetCategoryName?id=' + id)
            .map(response => { return response.json() as string; });
    }

    getMovieCategories(): Observable<any> {
        return this.http
            .get(this.endpoint + 'Categories')
            .map(response => { return response.json() as any; });
    }

    getMovieListByCategory(id: string): Observable<any> {
        return this.http
            .get(this.endpoint + 'MovieListbyCategory?catId=' + id)
            .map(response => { return response.json() as any; });
    }

    getMovie(id: string): Observable<any> {
        return this.http
            .get(this.endpoint + 'GetMovie?id=' + id)
            .map(response => { return response.json() as any; });
    }

    getMoviesByKey(key: string): Observable<any> {
        return this.http
            .get(this.endpoint + 'GetMovieByName?key=' + key)
            .map(response => { return response.json() as any; });
    }
}