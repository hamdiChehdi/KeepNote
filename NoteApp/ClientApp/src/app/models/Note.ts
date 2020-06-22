import { NoteType } from './NoteType';

export class Note {
  Id: number;
  Content: string;
  CreationDateTime: Date;
  LastUdpateDateTime: Date;
  NoteType: NoteType;
  PageId: number;
}
