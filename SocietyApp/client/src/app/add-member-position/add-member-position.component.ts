import { Component, Injector } from '@angular/core';
import { AddMemberPositionGenerated } from './add-member-position-generated.component';

@Component({
  selector: 'page-add-member-position',
  templateUrl: './add-member-position.component.html'
})
export class AddMemberPositionComponent extends AddMemberPositionGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
