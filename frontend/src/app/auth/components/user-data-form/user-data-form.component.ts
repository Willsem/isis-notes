import { Component, OnInit, EventEmitter, forwardRef, Input, Output } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ControlValueAccessor, FormBuilder, FormGroup, NG_VALUE_ACCESSOR } from '@angular/forms';

interface UserData {
  login: string;
  email: string;
  password: string;
  confirmPassword: string;
}

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
export class UserDataFormComponent implements OnInit, ControlValueAccessor {

  public userData = new BehaviorSubject({
    login: '',
    email: '',
    password: '',
    confirmPassword: ''
  } as UserData);

  public userDataForm: FormGroup;

  public get value(): UserData {
    return this.userData.value;
  }

  @Input()
  public set value(data: UserData) {
    this.userData.next(data);
  }

  @Output()
  public valueChange = new EventEmitter<UserData>();

  constructor(
    public fb: FormBuilder,
  ) {
    this.userDataForm = fb.group({
      login: '',
      email: '',
      password: '',
      confirmPassword: ''
    });

    this.userDataForm.valueChanges.subscribe(val => {
      this.value = val;
      this.valueChange.emit(val);
    });
  }

  public onChange = (_: any) => {};

  writeValue(obj: any): void {
    this.value = obj;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
  }

  ngOnInit(): void {
  }

}
