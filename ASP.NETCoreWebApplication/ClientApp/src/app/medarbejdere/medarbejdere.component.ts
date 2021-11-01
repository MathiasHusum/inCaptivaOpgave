import {Component, EventEmitter, OnInit, Output, ViewChild} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MedarbejderModel} from "../Models";
import {MatDialog, MatDialogRef} from "@angular/material/dialog";
import {MedarbejderCreateComponent} from "./medarbejder-create/medarbejder-create.component";

const MedarbejderMethods = {
  medarbejder: 'api/medarbejder'
}
@Component({
  selector: 'app-medarbejdere',
  templateUrl: './medarbejdere.component.html',
  styleUrls: ['./medarbejdere.component.css']
})
export class MedarbejdereComponent implements OnInit {
  medarbejdere: MedarbejderModel;
  http: HttpClient;
  newMedarbejderModel: MedarbejderModel;

  constructor(public dialog: MatDialog) {

  }

  ngOnInit() {
    this.getMedarbejdere();
  }
  getMedarbejdere(){
    this.http.get<MedarbejderModel>(MedarbejderMethods.medarbejder).subscribe(result => {
      this.medarbejdere = result;
    }, error => console.error(error))
  }
  getMedarbejder(id: number){
    this.http.get<MedarbejderModel>(MedarbejderMethods.medarbejder + id).subscribe(result => {
      this.medarbejdere = result;
    }, error => console.error(error))
  }
  openDialog(): void {
    const dialogRef = this.dialog.open(MedarbejderCreateComponent, {
      width: '250px',
      data: {firstName: this.newMedarbejderModel.firstName, lastName: this.newMedarbejderModel.lastName,
        age: this.newMedarbejderModel.age, vagter: this.newMedarbejderModel.vagter}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.newMedarbejderModel = result;
    });
  }
}
