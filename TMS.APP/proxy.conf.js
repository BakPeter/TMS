// import { environment } from './src/environments/environment';

// const target = environment.apiBaseUrl || 'https://localhost:7251/api/Tickets';
const target = 'https://localhost:7251/api/Tickets';

export default {
  '/api/getalltickets': {
    target,
    secure: false,
    changeOrigin: true,
    logLevel: 'debug',
    pathRewrite: { '^/api/getalltickets': 'api/tickets' },
  },
  '/api/updateticket': {
    target,
    secure: false,
    changeOrigin: true,
    logLevel: 'debug',
    pathRewrite: { '^/api/getalltickets': 'api/tickets' },
  },
};
