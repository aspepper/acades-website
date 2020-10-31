import { User } from './user'
import { PersonRole } from './personRole';

export class Person {
  id: number;
  name: string;
  document: string;
  user: Array<User>;
  roles: Array<PersonRole>;
  birthDate: Date; 
  isDeleted: boolean;
  insertDate: Date;
  insertUser: number;
  updateDate: Date;
  updateUser: number;
}