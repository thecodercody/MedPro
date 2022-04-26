import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {
  img5= "../../assets/images/img5.jpg";
  img6= "../../assets/images/img6.jpg";
  img7= "../../assets/images/img7.jpg";

  constructor() { }

  ngOnInit(): void {
  }

}
