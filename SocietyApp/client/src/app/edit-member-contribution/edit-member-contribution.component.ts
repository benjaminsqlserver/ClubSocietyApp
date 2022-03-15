import { Component, Injector } from '@angular/core';
import { EditMemberContributionGenerated } from './edit-member-contribution-generated.component';

@Component({
  selector: 'page-edit-member-contribution',
  templateUrl: './edit-member-contribution.component.html'
})
export class EditMemberContributionComponent extends EditMemberContributionGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
