import { Pipe, PipeTransform } from '@angular/core';
import { NoteType } from '../models/NoteType';

@Pipe({
  name: 'notetypetoicon'
})

export class NoteTypeToIcon implements PipeTransform {
  transform(noteType: NoteType) {
    return this.getIconName(noteType);
  }

  getIconName(noteType: NoteType) {
    switch (noteType) {
      case NoteType.Information:
        return 'info';
      case NoteType.Idea:
        return 'lightbulb_outline';
      default:
        return 'toc';
    }
  }
}
