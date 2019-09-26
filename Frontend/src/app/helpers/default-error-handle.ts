import { HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { throwError } from 'rxjs';

export function defaultErrorHandle(operation = 'execution') {
    return (err: any) => {
        let errorMessage = `Error on ${operation}.`;

        if (err instanceof HttpErrorResponse) {
            if (err.status === 400 && err.error) {

                if (typeof(err.error) === 'string') {
                    errorMessage += `\n${err.error}`;
                } else {
                    errorMessage += '\n' + JSON.stringify(err.error);
                }

            } else if (err.status && err.status !== 0) {
                errorMessage += `\n${err.status} - ${err.statusText}`;
            }
        }

        if (!environment.production) {
            console.log(`${errorMessage}:`, err);
        }

        return throwError(errorMessage);
    };
}
