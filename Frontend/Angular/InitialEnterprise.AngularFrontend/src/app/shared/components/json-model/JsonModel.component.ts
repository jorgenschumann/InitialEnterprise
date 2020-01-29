import { Component, OnInit, Input } from '@angular/core';
import { isDevMode } from '@angular/core';

@Component({
  selector: 'app-JsonModel',
  templateUrl: './JsonModel.component.html',
  styleUrls: ['./JsonModel.component.css']
})
export class JsonModelComponent {
  @Input() model: any;
  @Input() visible: boolean;
  constructor() {
    this.visible = isDevMode();
  }
}
