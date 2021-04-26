/**
 * Данные пользователя
 */
export interface User {
  /**
   * Id пользователя
   */
  id: string;
  /**
   * Идентификатор пользователя
   */
  username: string;
  /**
   * Email пользователя
   */
  email: string;
  /**
   * Аватар пользователя в формате base64
   */
  avatar: string;
}
