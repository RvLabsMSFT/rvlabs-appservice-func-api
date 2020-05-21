import { Component, OnInit } from '@angular/core';
import { EchoApiService } from '../../apis/echo-api.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-ezauth-echo-api',
  templateUrl: './ezauth-echo-api.component.html',
  styleUrls: ['./ezauth-echo-api.component.sass']
})
export class EzauthEchoApiComponent implements OnInit {

  constructor( private EchoApiService: EchoApiService) { }

  data$: Observable<any>;

  ngOnInit(): void {

    var payload = {
      fn: "Romer",
      ln: "Ventura",
      em: "romer@ventura.com",
      pic: "http://someurl.com/pic.svg"
    };

    this.data$ = this.EchoApiService.postUser(payload);
    this.data$.subscribe( res => { 
      console.log(res) 
    });

  }

}
