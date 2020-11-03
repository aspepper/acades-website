import { User } from './user'
import { PersonRole } from './personRole';

export class Person {
  id: number;
  name: string;
  document: string;
  birthDate: Date; 
  users: Array<User>;
  roles: Array<PersonRole>;
  isDeleted: boolean;
  insertDate: Date;
  insertUser: number;
  updateDate: Date;
  updateUser: number;
}