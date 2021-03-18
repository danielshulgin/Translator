import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from './../shared/services/authentication.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  public isUserAuthenticated: boolean;

  constructor(private _authService: AuthenticationService, private _router: Router) { }

  ngOnInit(): void {
    this._authService.authChanged
    .subscribe(res => {
      this.isUserAuthenticated = res;
    })
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public logout = () => {
    this._authService.logout();
    this._router.navigate(["/"]);
  }
}
