import { FileType } from './file-type';
import { Person } from './person'

export class File {

  public id: number;
  public fileTypeId: number;
  public fileType: FileType;
  public fileName: string;
  public fileNameOriginal: string;
  public fileExtension: string;
  public path: string;
  public personId: number;
  public person: Person;
  public isDeleted: boolean;
  public insertDate: Date;
  public insertUser: number;
  public updateDate: Date;
  public updateUser: number;

}

export class FileUploaded {
  public fileNameOriginal: string;
  public extension: string;
  public fileName: string;
  public absoluteUri: string;
}
