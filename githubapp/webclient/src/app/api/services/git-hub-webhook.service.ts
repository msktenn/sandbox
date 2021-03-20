/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { WeatherForecast } from '../models/weather-forecast';


/**
 * Operations for non-authenticated users
 */
@Injectable({
  providedIn: 'root',
})
export class GitHubWebhookService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiV1GitHubWebhookGet
   */
  static readonly ApiV1GitHubWebhookGetPath = '/api/v1/GitHubWebhook';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiV1GitHubWebhookGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubWebhookGet$Plain$Response(params?: {
  }): Observable<StrictHttpResponse<Array<WeatherForecast>>> {

    const rb = new RequestBuilder(this.rootUrl, GitHubWebhookService.ApiV1GitHubWebhookGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<WeatherForecast>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiV1GitHubWebhookGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubWebhookGet$Plain(params?: {
  }): Observable<Array<WeatherForecast>> {

    return this.apiV1GitHubWebhookGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<WeatherForecast>>) => r.body as Array<WeatherForecast>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiV1GitHubWebhookGet()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubWebhookGet$Response(params?: {
  }): Observable<StrictHttpResponse<Array<WeatherForecast>>> {

    const rb = new RequestBuilder(this.rootUrl, GitHubWebhookService.ApiV1GitHubWebhookGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<WeatherForecast>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiV1GitHubWebhookGet$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubWebhookGet(params?: {
  }): Observable<Array<WeatherForecast>> {

    return this.apiV1GitHubWebhookGet$Response(params).pipe(
      map((r: StrictHttpResponse<Array<WeatherForecast>>) => r.body as Array<WeatherForecast>)
    );
  }

}
