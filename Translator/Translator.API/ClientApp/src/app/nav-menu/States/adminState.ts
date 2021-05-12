import { Router } from "@angular/router";
import { NavMenuComponent } from "../nav-menu.component";
import { NavMenuState } from "./navMenuState";

export class NavMenuAdminState implements NavMenuState {
  constructor(private navMenuComponent: NavMenuComponent, private _router: Router) { }

  openTests(): void {
    //this._router.navigate();
    console.log("AdminState");
  }
}
