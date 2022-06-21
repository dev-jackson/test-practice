import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { UserLogin } from 'src/app/user/interfaces/user-login.interface';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {

  @ViewChild('email') email!: ElementRef<HTMLInputElement>;
  @ViewChild('password') password!: ElementRef<HTMLInputElement>;

  isValid: boolean = true; 

  constructor(private authService: AuthService, private router: Router) { }

  signIn(){
    const user: UserLogin = {
      email: this.email.nativeElement.value,
      password: this.password.nativeElement.value
    }
    this.authService.signIn(user).subscribe((value) => {
      localStorage.setItem('user', JSON.stringify(value));
      this.router.navigate(['/product']);
    },
    (res) => {
      console.log('Bad response', res);
      this.isValid = false;
    },);
  }

  ngOnInit(): void {
  }

}
