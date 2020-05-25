// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  coreapi: {
    endpoint: 'https://rvlabs-api-gateway.azurewebsites.net/',
    api: {
      top10: 'api/movies/top10',
      categories: 'api/movies/categories',
      all: 'api/movies/all',
      func: 'api/func'
    }
  },
  funcapi: {
    endpoint: 'https://rvlabs-api.azurewebsites.net/',
    api: {
      categories: 'api/movies/categories'
    }
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
