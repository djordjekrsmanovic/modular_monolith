import { environment } from '../environments/environment.prod';
export const server: string = environment.backend_url || 'http://fallback-url/';
