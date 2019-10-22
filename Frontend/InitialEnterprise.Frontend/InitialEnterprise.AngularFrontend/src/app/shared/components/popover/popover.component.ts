import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-popover',
  templateUrl: './popover.component.html',
  styleUrls: ['./popover.component.css']
})
export class PopoverComponent implements OnInit {

  @Input() infoContent: string;
  @Input() infoTitle: string;


  constructor() { }

  ngOnInit() {
  }
}
