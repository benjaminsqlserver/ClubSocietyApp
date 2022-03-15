import { Component, Injector } from '@angular/core';
import { MemberPositionsGenerated } from './member-positions-generated.component';

@Component({
  selector: 'page-member-positions',
  templateUrl: './member-positions.component.html'
})
export class MemberPositionsComponent extends MemberPositionsGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
