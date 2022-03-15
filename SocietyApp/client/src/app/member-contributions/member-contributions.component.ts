import { Component, Injector } from '@angular/core';
import { MemberContributionsGenerated } from './member-contributions-generated.component';

@Component({
  selector: 'page-member-contributions',
  templateUrl: './member-contributions.component.html'
})
export class MemberContributionsComponent extends MemberContributionsGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
