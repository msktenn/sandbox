import { Component } from '@angular/core';
import { Auth } from 'aws-amplify'


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  title = 'login';

  async onClickMe() {
    try {
      //      const { user } = await Auth.configure();
      Auth.
        console.log("Hello World");
    } catch (error) {
      console.log('error signing up:', error);
    }
  }

}
