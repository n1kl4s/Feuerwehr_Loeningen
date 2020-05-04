import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiEndpoint } from '../constants/ApiEndpoint';
import { Engine } from '../model/engine';

@Injectable({
  providedIn: 'root'
})
export class EngineService {

  constructor(private httpClient: HttpClient) {}

  vehicel: Engine;

  /**
   * Request all Engines from the server
   */
  public requestAllEngines() {
    return this.httpClient.get(ApiEndpoint.API_ENGINES);
  }


}
