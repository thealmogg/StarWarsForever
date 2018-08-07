import { ErrorHandler, Inject, NgZone } from '../../node_modules/@angular/core';
import { ToastyService } from '../../node_modules/ng2-toasty';

export class AppErrorHandler implements ErrorHandler {
  constructor(private ngZone: NgZone,
    @Inject(ToastyService) private toastyService: ToastyService) {}

  handleError(error: any): void {

    this.ngZone.run(() => {
      console.log(error);
        this.toastyService.error({
          title: 'Error ' + error.status,
          msg: 'An Unexpected Error Occured',
          theme: 'bootstrap',
          showClose: true,
          timeout: 5000
        });
      });
  }

}
