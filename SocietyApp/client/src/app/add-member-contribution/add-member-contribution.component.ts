import { Component, Injector } from '@angular/core';
import { AddMemberContributionGenerated } from './add-member-contribution-generated.component';

@Component({
  selector: 'page-add-member-contribution',
  templateUrl: './add-member-contribution.component.html'
})
export class AddMemberContributionComponent extends AddMemberContributionGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
