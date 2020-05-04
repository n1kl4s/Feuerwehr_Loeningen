import { environment } from 'src/environments/environment';

export class ApiEndpoint {

    public static readonly API: string = environment.api;

    public static readonly API_ENGINES: string = ApiEndpoint.API + '/Engines/';

}
