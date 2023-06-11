import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import {Injectable} from "@angular/core"
import { AuthService } from "app/services/auth.service";
import { tap,map , Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class AuthGuard implements CanActivate{
    constructor(private authService:AuthService,private router:Router){}
    canActivate(
        route:ActivatedRouteSnapshot,
        state:RouterStateSnapshot):boolean | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
            let user = JSON.parse(localStorage.getItem("lawyer"))
            let result;
                result = !!user && user.role === "lawyers"
            if(!result){
                return this.router.navigate(['/login'])
            }

    }
}