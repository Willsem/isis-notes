import { Component, EventEmitter, forwardRef, Input, Output } from '@angular/core';
import {
  ControlValueAccessor,
  FormBuilder,
  FormGroup,
  NG_VALUE_ACCESSOR,
  Validators
} from '@angular/forms';

/**
 * Интерфейс представления формы информации о пользователе
 */
interface UserData {
  /**
   * Логин пользователя
   */
  login: string;
  /**
   * Email пользователя
   */
  email: string;
  /**
   * Пароль пользователя
   */
  password: string;
  /**
   * Повторный пароль пользователя
   */
  confirmPassword: string;
}

/**
 * Компонент ввода информации о пользователе для редактирования или создания пользователя
 */
@Component({
  selector: 'isis-user-data-form',
  templateUrl: './user-data-form.component.html',
  styleUrls: ['./user-data-form.component.css'],
  providers: [{
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => UserDataFormComponent),
    multi: true
  }],
})
export class UserDataFormComponent implements ControlValueAccessor {

  /**
   * Группа контроллеров формы ввода информации о пользователе
   */
  public userDataForm: FormGroup;

  /**
   * Получить данные формы ввода информации о пользователе
   */
  public get value(): UserData {
    return this.userDataForm.value;
  }

  /**
   * Установить значение формы ввода информации о пользователе
   * @param data Данные пользователя
   */
  @Input()
  public set value(data: UserData) {
    this.userDataForm.setValue(data);
    this.onChange(data);
  }

  /**
   * Отправитель событий изменения данных формы
   */
  @Output()
  public valueChange = new EventEmitter<UserData>();

  /**
   * Конструктор
   *
   * @param fb Строитель форм
   */
  constructor(
    public fb: FormBuilder,
  ) {
    this.userDataForm = fb.group({
      login: ['', [Validators.required]],
      email: ['', [Validators.email]],
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]],
    });

    this.userDataForm.valueChanges.subscribe(val => {
      if (this.userDataForm.valid) {
        this.valueChange.emit(val);
        this.onChange(val);
      } else {
        const newVal = {
          login: '',
          email: '',
          password: '',
          confirmPassword: ''
        };
        this.valueChange.emit(newVal);
        this.onChange(newVal);
      }
    });
  }

  /**
   * Обработчик изменения данных формы извне
   *
   * @param _ данные формы
   */
  public onChange = (_: any) => {};

  /**
   * Запись значения формы
   * @param obj Данные для записи
   */
  writeValue(obj: any): void {
    this.value = obj;
  }

  /**
   * Регистрация обработчика изменений данных формы
   *
   * @param fn Обработчик
   */
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  /**
   * Регистрация обработчика событий касания
   *
   * @param fn Обработчик
   */
  registerOnTouched(fn: any): void {
  }

}
