import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { CardComponent } from './card/card.component';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
   declarations: [
      AppComponent,
      CardComponent
   ],
   imports: [
     BrowserModule,
     FormsModule,
     HttpClientModule
   ],
   providers: [
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
