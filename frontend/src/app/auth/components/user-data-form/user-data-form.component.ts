import { Component, OnInit, EventEmitter, forwardRef, Input, Output } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import {
  AbstractControl,
  ControlValueAccessor,
  FormBuilder,
  FormControl,
  FormGroup,
  NG_VALUE_ACCESSOR,
  ValidatorFn,
  Validators
} from '@angular/forms';

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

  public userDataForm: FormGroup;

  public get value(): UserData {
    return this.userDataForm.value;
  }

  @Input()
  public set value(data: UserData) {
    this.userDataForm.setValue(data);
    this.onChange(data);
  }

  @Output()
  public valueChange = new EventEmitter<UserData>();

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
