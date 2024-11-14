import { Component, OnInit } from '@angular/core';
import { GitHubCallbackService } from './api/services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  items: Array<string> = [];



  constructor(
    private readonly githubCallback: GitHubCallbackService,
  ) {
    console.log("what");
  }

  ngOnInit() {
    console.log("here");
    this.githubCallback.apiV1GitHubCallbackGet().subscribe(result => {
      console.log("here 2");
      this.items = result;
    });
  }

  githubLogin() {
    console.log("github login");
    window.location.href = "";

  }
}
