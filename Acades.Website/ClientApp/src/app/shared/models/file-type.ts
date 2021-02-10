export class FileType {

  public id: number;
  public description: string;
  public isDeleted: boolean;
  public insertDate: Date;
  public insertUser: number;
  public updateDate: Date;
  public updateUser: number;

}

export enum FileTypes {
  Curriculo = 1,
  FotoPerfil = 2,
}