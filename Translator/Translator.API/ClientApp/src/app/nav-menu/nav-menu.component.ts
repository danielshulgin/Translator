import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from './../shared/services/authentication.service';
import { NavMenuAdminState } from './States/adminState';
import { NavMenuState } from './States/navMenuState';
import { NavMenuUnloggedState } from './States/navMenuUnloggedState';
import { NavMenuUserState } from './States/navMenuUserState';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  public isExpanded = false;
  public isUserAuthenticated: boolean;
  private navMenuState: NavMenuState;

  constructor(private _authService: AuthenticationService, private _router: Router) { }

  public ngOnInit(): void {
    this._authService.authChanged
    .subscribe(this.onLoggedStateChanged);
    this.onLoggedStateChanged(this._authService.isUserAuthenticated());
  }

  public onLoggedStateChanged(res:boolean){
    this.isUserAuthenticated = res;
    let isUserAdmin = this._authService.isUserAdmin;
    if(isUserAdmin && this.isUserAuthenticated){
      this.navMenuState = new NavMenuAdminState(this, this._router);
    } else if (this.isUserAuthenticated){
      this.navMenuState = new NavMenuUserState(this, this._router);
    } else{
      this.navMenuState = new NavMenuUnloggedState(this, this._router);
    }
  }

  public collapse() {
    this.isExpanded = false;
  }

  public toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public logout = () => {
    this._authService.logout();
    this._router.navigate(["/"]);
  }

  public openTests = () =>{
    this.navMenuState.openTests();
  }
}
