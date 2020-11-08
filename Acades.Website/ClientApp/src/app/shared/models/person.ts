import { User } from './user'
import { PersonRole } from './personRole';
import { File } from './file';

export class Person {
  id: number;
  name: string;
  document: string;
  birthDate: Date; 
  users: Array<User>;
  roles: Array<PersonRole>;
  files: Array<File>;
  isDeleted: boolean;
  insertDate: Date;
  insertUser: number;
  updateDate: Date;
  updateUser: number;
}