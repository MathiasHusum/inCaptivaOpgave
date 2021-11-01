import {HttpClient} from "@angular/common/http";
import { Injectable } from '@angular/core';
import {Router} from "@angular/router";
import {Observable} from "rxjs";
import {MedarbejderModel} from "../../Models";


const MedarbejderMethods = {
  medarbejder: 'api/medarbejder'
}
@Injectable({
  providedIn: 'root'
})
export class MedarbejderServiceService {

  constructor(private _http: HttpClient, router: Router) {
  }

}
