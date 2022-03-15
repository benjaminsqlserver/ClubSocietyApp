import { Component, Injector } from '@angular/core';
import { EditMemberGenerated } from './edit-member-generated.component';

@Component({
  selector: 'page-edit-member',
  templateUrl: './edit-member.component.html'
})
export class EditMemberComponent extends EditMemberGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
