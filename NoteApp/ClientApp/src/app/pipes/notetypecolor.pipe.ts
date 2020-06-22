import { Pipe, PipeTransform } from '@angular/core';
import { NoteType } from '../models/NoteType';

@Pipe({
  name: 'notetypetocolor'
})

export class NoteTypeToColor implements PipeTransform {
  transform(noteType: NoteType) {
    return this.getColor(noteType);
  }

  getColor(noteType: NoteType) {
    switch (noteType) {
      case NoteType.Information:
        return '#CCFF90';
      case NoteType.Idea:
        return '#FDCFE8';
      default:
        return '#CBF0F8';
    }
  }
}
