import { Component, Injector } from '@angular/core';
import { AddMemberGenerated } from './add-member-generated.component';

@Component({
  selector: 'page-add-member',
  templateUrl: './add-member.component.html'
})
export class AddMemberComponent extends AddMemberGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
