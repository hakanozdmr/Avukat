import {Input, Component, Renderer2, ElementRef, ChangeDetectorRef} from '@angular/core';

@Component({
  selector: 'ngx-loading',
  template: `
    <div id="blocker" class="blocker" *ngIf="showIf">
      <mat-spinner color="warn" [diameter]="diameter"></mat-spinner>
    </div>
    <ng-content class="content"></ng-content>
  `,
  styles: [`
    :host {
      position: relative;
      display: inline-block;
    }
    .blocker {
      display:flex;
      justify-content: center;
      align-items: center;
      position: absolute;
      width: 100%;
      height: 100%;
      z-index: 999;
      background-color: #fff;
      opacity: 0.5;
    }
  `],
})
export class NgxLoadingComponent {
  @Input('showIf') showIf: boolean;
  diameter: number = 20;

  constructor(
    private renderer: Renderer2,
    private el: ElementRef,
    private changeDetector: ChangeDetectorRef
  ) {}


  ngAfterViewInit() {
    // spinner block
    let blocker: any = this.el.nativeElement.querySelector('.blocker');

    // user element
    let firstChild: any = Array.from(this.el.nativeElement.children)
      .find(el => el !== blocker);

    if (firstChild) { //if text, this is null 
      let firstChildStyle = window.getComputedStyle(firstChild);
      // if user element is a block, change this element to block
      if (firstChildStyle.display === 'block') {
        this.el.nativeElement.style.display = 'block'
      };
      // if user element has borderRadius, make blocker the same
      if (firstChildStyle.borderRadius) {
        blocker.style.borderRadius = firstChildStyle.borderRadius;
      }
      // if the user element is big, change the spinner size bigger 
      if (parseInt(firstChild.style.height) >= 200) {
        this.diameter = 40;
        this.changeDetector.detectChanges();
      }
    }
  }
    
}
