import { Directive, ViewContainerRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appDropdown]'
})
export class DropdownDirective {

    // @HostBinding('class.show')
    isOpen = false;
    menuId: string;
    constructor(private vContainer: ViewContainerRef) {

    }
    @Input('appDropdown') set unless(value: string) {
      this.menuId = '#' + value;
    }
    @HostListener('click')
    ddClicked() {
      this.closeAllDropDowns();
        if (!this.isOpen) {
            this.vContainer.element.nativeElement.parentElement.querySelector(this.menuId).classList.add('show');
        } else {
            this.vContainer.element.nativeElement.parentElement.querySelector(this.menuId).classList.remove('show');
        }
        this.isOpen = !this.isOpen;
    }

    closeAllDropDowns() {
      const dropDownElements = this.vContainer.element.nativeElement.parentElement.querySelectorAll('.dropdown-menu');
      for (const ddE of dropDownElements) {
        ddE.classList.remove('show');
      }
    }

}
