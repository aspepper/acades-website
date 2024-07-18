import { Person } from './person';
import { Role } from './role';

export class PersonRole {

  id: number;
  person: Person;
  personId: number;
  role: Role;
  roleId: number;
  isDeleted: boolean;
  insertDate: Date;
  insertUser: number;
  updateDate: Date;
  updateUser: number;

}