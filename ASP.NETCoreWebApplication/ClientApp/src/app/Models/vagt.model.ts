import {MedarbejderModel} from "./medarbejder.model";
import {OpgaveModel} from "./opgave.model";

export class VagtModel {
  vagtID: number;
  start: Date;
  end: Date;
  medarbejder: MedarbejderModel;
  opgaver: Array<OpgaveModel> = [];
}
