import { Component, Injector } from '@angular/core';
import { MembersGenerated } from './members-generated.component';

@Component({
  selector: 'page-members',
  templateUrl: './members.component.html'
})
export class MembersComponent extends MembersGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
