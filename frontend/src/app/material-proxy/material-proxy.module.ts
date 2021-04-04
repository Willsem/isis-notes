import { NgModule } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';

const materialModules = [
  MatInputModule,
  MatFormFieldModule,
  MatButtonModule,
];

@NgModule({
  imports: materialModules,
  exports: materialModules
})
export class MaterialProxyModule { }
