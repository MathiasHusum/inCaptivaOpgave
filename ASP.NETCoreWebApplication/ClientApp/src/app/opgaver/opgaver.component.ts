import { Component, OnInit } from '@angular/core';
import {MedarbejderModel, OpgaveModel} from "../Models";
import {HttpClient} from "@angular/common/http";
import {MedarbejderCreateComponent} from "../medarbejdere/medarbejder-create/medarbejder-create.component";
import {MatDialog, MatDialogRef} from "@angular/material/dialog";
import {OpgaveCreateComponent} from "./opgave-create/opgave-create.component";

const OpgaverMethods = {
  opgaver: "api/opgave"
}

@Component({
  selector: 'app-opgaver',
  templateUrl: './opgaver.component.html',
  styleUrls: ['./opgaver.component.css']
})
export class OpgaverComponent implements OnInit {
  http: HttpClient;

  opgaver: OpgaveModel;
  newOpgave: OpgaveModel = new OpgaveModel();
  constructor(public dialog: MatDialog) { }

  ngOnInit() {
  this.getOpgaver();
  }
  getOpgaver(){
    this.http.get<OpgaveModel>(OpgaverMethods.opgaver).subscribe(result => {
      this.opgaver = result;
    }, error => console.error(error))
  }
  getOpgave(id: number){
    this.http.get<OpgaveModel>(OpgaverMethods.opgaver + id).subscribe(result => {
      this.opgaver = result;
    }, error => console.error(error))
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(OpgaveCreateComponent, {
      width: '1000px',
      data: {
        name: this.newOpgave.name, ageRestriction: this.newOpgave.ageRestriction,
        description: this.newOpgave.description
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('${result} was created');

    });
  }
}
