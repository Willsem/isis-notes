import { User } from './user';
import { Moment } from 'moment';

/**
 * Текущая сессия пользователя
 */
export interface Session {
  /**
   * Id сессии
   */
  id: string;
  /**
   * JWT токен сессии
   */
  token: string;
  /**
   * объект текущего пользователя
   */
  user: User;
  /**
   * Время создания сессии
   */
  timestamp: Moment;
}
