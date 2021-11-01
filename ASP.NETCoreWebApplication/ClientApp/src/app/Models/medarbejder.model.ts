import {VagtModel} from "./vagt.model";

export class MedarbejderModel {
  medarbejderId: number;
  firstName: string;
  lastName: string;
  age: number;
  vagter: Array<VagtModel> = [];
}
