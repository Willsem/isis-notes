import { User } from './user';
import { Moment } from 'moment';

export interface Session {
  id: string;
  token: string;
  user: User;
  timestamp: Moment;
}
