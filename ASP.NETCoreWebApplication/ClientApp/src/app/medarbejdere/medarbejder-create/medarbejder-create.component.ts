import {Component, EventEmitter, Inject, OnInit, Output, ViewChild} from '@angular/core';
import {MedarbejderModel, VagtModel} from "../../Models";
import {HttpClient} from "@angular/common/http";
import {MAT_DIALOG_DATA, MatDialog, MatDialogConfig, MatDialogRef} from "@angular/material/dialog";

const MedarbejderMethods = {
  medarbejder: 'api/medarbejder'
}
@Component({
  selector: 'app-medarbejder-create',
  templateUrl: './medarbejder-create.component.html',
  styleUrls: ['./medarbejder-create.component.css']
})
export class MedarbejderCreateComponent implements OnInit {
@Output() onMedarbejderCreated: EventEmitter<void> = new EventEmitter<void>();
newMedarbejderModel: MedarbejderModel = new MedarbejderModel();
vagterModel: VagtModel;
  http: HttpClient;



constructor(public dialogRef: MatDialogRef<MedarbejderCreateComponent>, @Inject(MAT_DIALOG_DATA) public data: MedarbejderModel) { }

  ngOnInit() {
  }

  show() {
  this.newMedarbejderModel = new MedarbejderModel();
  }

  createMedarbejder(model: MedarbejderModel) {
    this.http.post(MedarbejderMethods.medarbejder, model).subscribe(result => {
      this.newMedarbejderModel = new MedarbejderModel();
    })
  }
  onNoClick(): void {
    this.dialogRef.close();
  }

}
