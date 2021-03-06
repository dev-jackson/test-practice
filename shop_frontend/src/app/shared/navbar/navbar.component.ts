import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
})
export class NavbarComponent implements OnInit {

  isActiveSession: boolean;

  constructor(private authService: AuthService) {
    this.isActiveSession = authService.isSessionExist();
  }

  layout(){
    this.authService.layout();
  }

  ngOnInit(): void {
  }

}
