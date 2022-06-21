import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { ErrorPageComponent } from './error-page/error-page.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [NavbarComponent, ErrorPageComponent],
  imports: [
    CommonModule,
    RouterModule,
  ],
  exports:[
    ErrorPageComponent,
    NavbarComponent
  ]
})
export class SharedModule { }
