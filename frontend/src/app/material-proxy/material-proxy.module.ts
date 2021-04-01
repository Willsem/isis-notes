import { NgModule } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';


const materialModules = [
  MatInputModule,
  MatFormFieldModule,
];

@NgModule({
  imports: materialModules,
  exports: materialModules
})
export class MaterialProxyModule { }
