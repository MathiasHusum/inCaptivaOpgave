import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {OpgaveModel} from "../../Models";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

const OpgaverMethods = {
  opgaver: "api/opgave"
}

@Component({
  selector: 'app-opgave-create',
  templateUrl: './opgave-create.component.html',
  styleUrls: ['./opgave-create.component.css']
})
export class OpgaveCreateComponent implements OnInit {
  http: HttpClient;
  newOpgaveModel: OpgaveModel;
  constructor(public dialogRef: MatDialogRef<OpgaveCreateComponent>, @Inject(MAT_DIALOG_DATA) public data: OpgaveModel) { }

  ngOnInit() {
  }
  createOpgave(model: OpgaveModel) {
      this.http.post(OpgaverMethods.opgaver, model).subscribe(result => {
        this.newOpgaveModel = new OpgaveModel();
    })
  }
  onNoClick(): void {
    this.dialogRef.close();
    this.newOpgaveModel = new OpgaveModel();
  }
}
