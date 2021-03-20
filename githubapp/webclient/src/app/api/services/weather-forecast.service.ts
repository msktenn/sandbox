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
export class WeatherForecastService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiV1WeatherForecastGet
   */
  static readonly ApiV1WeatherForecastGetPath = '/api/v1/WeatherForecast';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiV1WeatherForecastGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1WeatherForecastGet$Plain$Response(params?: {
  }): Observable<StrictHttpResponse<Array<WeatherForecast>>> {

    const rb = new RequestBuilder(this.rootUrl, WeatherForecastService.ApiV1WeatherForecastGetPath, 'get');
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
   * To access the full response (for headers, for example), `apiV1WeatherForecastGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1WeatherForecastGet$Plain(params?: {
  }): Observable<Array<WeatherForecast>> {

    return this.apiV1WeatherForecastGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<WeatherForecast>>) => r.body as Array<WeatherForecast>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiV1WeatherForecastGet()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1WeatherForecastGet$Response(params?: {
  }): Observable<StrictHttpResponse<Array<WeatherForecast>>> {

    const rb = new RequestBuilder(this.rootUrl, WeatherForecastService.ApiV1WeatherForecastGetPath, 'get');
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
   * To access the full response (for headers, for example), `apiV1WeatherForecastGet$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1WeatherForecastGet(params?: {
  }): Observable<Array<WeatherForecast>> {

    return this.apiV1WeatherForecastGet$Response(params).pipe(
      map((r: StrictHttpResponse<Array<WeatherForecast>>) => r.body as Array<WeatherForecast>)
    );
  }

}
