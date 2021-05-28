import { Router } from "@angular/router";
import { NavMenuComponent } from "../nav-menu.component";
import { NavMenuState } from "./navMenuState";

export class NavMenuUnloggedState implements NavMenuState {
  constructor(private navMenuComponent: NavMenuComponent, private _router: Router) { }

  openTests(): void {
    //this._router.navigate(["/authentication/login"]);
    this._router.navigate(["/tests"]);
    console.log("UnloggedState");
  }
}
