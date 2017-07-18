import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpModule, Http } from '@angular/http';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { MovieModule } from './movie/movie.module';
import { FormsModule } from '@angular/forms';
import { MovieService } from './movie/movie.service';


@NgModule({
    declarations: [AppComponent],
    imports: [HttpModule, BrowserAnimationsModule, AppRoutingModule, MovieModule, FormsModule],
    bootstrap: [AppComponent],
    providers: [MovieService]
})

export class AppModule {

}