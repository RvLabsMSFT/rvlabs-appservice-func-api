import { Component, OnInit } from '@angular/core';
import { CoreapiComponent } from 'src/app/coreapi/coreapi.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent implements OnInit{
  title = 'web-portal';

  constructor( private CoreApi: CoreapiComponent ){}

  ngOnInit(): void {
  }

  SelectApiOperation( param ) {
    this.CoreApi.SetApiOperation( param );
    console.log( param );

  }
}
