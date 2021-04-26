import { User } from './user';
import { Login } from './login';

/**
 * Структура, содержащая данные пользователя для редактирования
 */
export interface UserLogin {
  /**
   * Объект пользователя
   */
  user: User;
  /**
   * Данные пользователя для авторизации
   */
  login: Login;
}
