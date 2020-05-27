import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/coreapi/api.service';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-coreapi',
  templateUrl: './coreapi.component.html',
  styleUrls: ['./coreapi.component.sass']
})
export class CoreapiComponent implements OnInit {

  data$: Observable<any>;

  constructor( private ApiService: ApiService ) { }

  ngOnInit(): void {
  }

  SetApiOperation( operation ) {

    switch (operation) {
      case 'TopTen':
        this.GetCoreApi( environment.coreapi.api.top10 );
        break;
      case 'All':
        this.GetCoreApi( environment.coreapi.api.all );
        break;
      case 'Func':
        this.GetCoreApi( environment.coreapi.api.func );
        break;
      default:
        break;
    }
  }

  GetCoreApi( operation ): void {

    this.data$ = this.ApiService.SendGetRequest( environment.coreapi.endpoint, operation );
    this.data$.subscribe( res => { 
      console.log(res) 
    });

  }

}
