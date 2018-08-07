import { Directive, ViewContainerRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appCollapse]'
})
export class CollapseDirective {

    // @HostBinding('class.show')
    isOpen = false;
    menuId: string;
    constructor(private vContainer: ViewContainerRef) {

    }
    @Input('appCollapse') set unless(value: string) {
      this.menuId = '#' + value;
    }
    @HostListener('click')
    collapseClicked() {
        if (!this.isOpen) {
          this.vContainer.element.nativeElement.parentElement.querySelector(this.menuId).classList.add('show');
          this.vContainer.element.nativeElement.classList.add('collapsed');
        } else {
          this.vContainer.element.nativeElement.parentElement.querySelector(this.menuId).classList.remove('show');
          this.vContainer.element.nativeElement.classList.remove('collapsed');
        }
        this.isOpen = !this.isOpen;
    }


}
