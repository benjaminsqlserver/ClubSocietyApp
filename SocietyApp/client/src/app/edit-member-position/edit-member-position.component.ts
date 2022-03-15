import { Component, Injector } from '@angular/core';
import { EditMemberPositionGenerated } from './edit-member-position-generated.component';

@Component({
  selector: 'page-edit-member-position',
  templateUrl: './edit-member-position.component.html'
})
export class EditMemberPositionComponent extends EditMemberPositionGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
