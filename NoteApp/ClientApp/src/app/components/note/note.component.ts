import { Component, OnInit, Input } from '@angular/core';
import { Note } from 'src/app/models/Note';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.css']
})
export class NoteComponent implements OnInit {

  constructor() { }

  @Input() NoteData: Note;

  ngOnInit(): void {
  }

}
