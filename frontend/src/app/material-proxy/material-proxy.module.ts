import { NgModule } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';

const materialModules = [
  MatInputModule,
  MatFormFieldModule,
  MatButtonModule,
  MatSidenavModule,
];

@NgModule({
  imports: materialModules,
  exports: materialModules
})
export class MaterialProxyModule { }
