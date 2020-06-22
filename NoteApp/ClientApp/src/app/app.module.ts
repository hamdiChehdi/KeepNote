import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import {MatGridListModule} from '@angular/material/grid-list';
import { PagesComponent } from './components/pages/pages.component';
import {MatListModule} from '@angular/material/list';
import { PageComponent } from './components/page/page.component';
import { PageContentComponent } from './components/page-content/page-content.component';
import { NoteListComponent } from './components/note-list/note-list.component';
import { EventListComponent } from './components/event-list/event-list.component';
import {MatExpansionModule} from '@angular/material/expansion';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { NoteComponent } from './components/note/note.component';
import { NoteTypeToIcon } from './pipes/notetypeicon.pipe';
import { NoteTypeToColor } from './pipes/notetypecolor.pipe';

@NgModule({
  declarations: [
    AppComponent,
    PagesComponent,
    PageComponent,
    PageContentComponent,
    NoteListComponent,
    EventListComponent,
    NoteComponent,
    NoteTypeToIcon,
    NoteTypeToColor
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatExpansionModule,
    MatGridListModule,
    FormsModule,
    BrowserAnimationsModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
