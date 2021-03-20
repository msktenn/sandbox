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



/**
 * Operations for non-authenticated users
 */
@Injectable({
  providedIn: 'root',
})
export class GitHubCallbackService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiV1GitHubCallbackGet
   */
  static readonly ApiV1GitHubCallbackGetPath = '/api/v1/GitHubCallback';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiV1GitHubCallbackGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubCallbackGet$Plain$Response(params?: {
  }): Observable<StrictHttpResponse<Array<string>>> {

    const rb = new RequestBuilder(this.rootUrl, GitHubCallbackService.ApiV1GitHubCallbackGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<string>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiV1GitHubCallbackGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubCallbackGet$Plain(params?: {
  }): Observable<Array<string>> {

    return this.apiV1GitHubCallbackGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<string>>) => r.body as Array<string>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiV1GitHubCallbackGet()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubCallbackGet$Response(params?: {
  }): Observable<StrictHttpResponse<Array<string>>> {

    const rb = new RequestBuilder(this.rootUrl, GitHubCallbackService.ApiV1GitHubCallbackGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<string>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiV1GitHubCallbackGet$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubCallbackGet(params?: {
  }): Observable<Array<string>> {

    return this.apiV1GitHubCallbackGet$Response(params).pipe(
      map((r: StrictHttpResponse<Array<string>>) => r.body as Array<string>)
    );
  }

  /**
   * Path part for operation apiV1GitHubCallbackPut
   */
  static readonly ApiV1GitHubCallbackPutPath = '/api/v1/GitHubCallback';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiV1GitHubCallbackPut()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubCallbackPut$Response(params?: {
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, GitHubCallbackService.ApiV1GitHubCallbackPutPath, 'put');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiV1GitHubCallbackPut$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubCallbackPut(params?: {
  }): Observable<void> {

    return this.apiV1GitHubCallbackPut$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiV1GitHubCallbackPost
   */
  static readonly ApiV1GitHubCallbackPostPath = '/api/v1/GitHubCallback';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiV1GitHubCallbackPost()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubCallbackPost$Response(params?: {
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, GitHubCallbackService.ApiV1GitHubCallbackPostPath, 'post');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiV1GitHubCallbackPost$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubCallbackPost(params?: {
  }): Observable<void> {

    return this.apiV1GitHubCallbackPost$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiV1GitHubCallbackDelete
   */
  static readonly ApiV1GitHubCallbackDeletePath = '/api/v1/GitHubCallback';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiV1GitHubCallbackDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubCallbackDelete$Response(params?: {
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, GitHubCallbackService.ApiV1GitHubCallbackDeletePath, 'delete');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiV1GitHubCallbackDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubCallbackDelete(params?: {
  }): Observable<void> {

    return this.apiV1GitHubCallbackDelete$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiV1GitHubCallbackPatch
   */
  static readonly ApiV1GitHubCallbackPatchPath = '/api/v1/GitHubCallback';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiV1GitHubCallbackPatch()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubCallbackPatch$Response(params?: {
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, GitHubCallbackService.ApiV1GitHubCallbackPatchPath, 'patch');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiV1GitHubCallbackPatch$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1GitHubCallbackPatch(params?: {
  }): Observable<void> {

    return this.apiV1GitHubCallbackPatch$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
