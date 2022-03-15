import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { GendersComponent } from './genders/genders.component';
import { AddGenderComponent } from './add-gender/add-gender.component';
import { EditGenderComponent } from './edit-gender/edit-gender.component';
import { MembersComponent } from './members/members.component';
import { AddMemberComponent } from './add-member/add-member.component';
import { EditMemberComponent } from './edit-member/edit-member.component';
import { MemberContributionsComponent } from './member-contributions/member-contributions.component';
import { AddMemberContributionComponent } from './add-member-contribution/add-member-contribution.component';
import { EditMemberContributionComponent } from './edit-member-contribution/edit-member-contribution.component';
import { MemberPositionsComponent } from './member-positions/member-positions.component';
import { AddMemberPositionComponent } from './add-member-position/add-member-position.component';
import { EditMemberPositionComponent } from './edit-member-position/edit-member-position.component';
import { ApplicationUsersComponent } from './application-users/application-users.component';
import { ApplicationRolesComponent } from './application-roles/application-roles.component';
import { RegisterApplicationUserComponent } from './register-application-user/register-application-user.component';
import { LoginComponent } from './login/login.component';
import { AddApplicationUserComponent } from './add-application-user/add-application-user.component';
import { EditApplicationUserComponent } from './edit-application-user/edit-application-user.component';
import { AddApplicationRoleComponent } from './add-application-role/add-application-role.component';
import { ProfileComponent } from './profile/profile.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

import { SecurityService } from './security.service';
import { AuthGuard } from './auth.guard';
export const routes: Routes = [
  { path: '', redirectTo: '/members', pathMatch: 'full' },
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: 'genders',
        canActivate: [AuthGuard],
        data: {
          roles: ['SuperAdmin'],
        },
        component: GendersComponent
      },
      {
        path: 'add-gender',
        canActivate: [AuthGuard],
        data: {
          roles: ['SuperAdmin'],
        },
        component: AddGenderComponent
      },
      {
        path: 'edit-gender/:GenderID',
        canActivate: [AuthGuard],
        data: {
          roles: ['SuperAdmin'],
        },
        component: EditGenderComponent
      },
      {
        path: 'members',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: MembersComponent
      },
      {
        path: 'add-member',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddMemberComponent
      },
      {
        path: 'edit-member/:MemberID',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EditMemberComponent
      },
      {
        path: 'member-contributions',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: MemberContributionsComponent
      },
      {
        path: 'add-member-contribution',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddMemberContributionComponent
      },
      {
        path: 'edit-member-contribution/:ContributionID',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EditMemberContributionComponent
      },
      {
        path: 'member-positions',
        canActivate: [AuthGuard],
        data: {
          roles: ['SuperAdmin'],
        },
        component: MemberPositionsComponent
      },
      {
        path: 'add-member-position',
        canActivate: [AuthGuard],
        data: {
          roles: ['SuperAdmin'],
        },
        component: AddMemberPositionComponent
      },
      {
        path: 'edit-member-position/:PositionID',
        canActivate: [AuthGuard],
        data: {
          roles: ['SuperAdmin'],
        },
        component: EditMemberPositionComponent
      },
      {
        path: 'application-users',
        canActivate: [AuthGuard],
        data: {
          roles: ['SuperAdmin'],
        },
        component: ApplicationUsersComponent
      },
      {
        path: 'application-roles',
        canActivate: [AuthGuard],
        data: {
          roles: ['SuperAdmin'],
        },
        component: ApplicationRolesComponent
      },
      {
        path: 'register-application-user',
        canActivate: [AuthGuard],
        data: {
          roles: ['SuperAdmin'],
        },
        component: RegisterApplicationUserComponent
      },
      {
        path: 'add-application-user',
        canActivate: [AuthGuard],
        data: {
          roles: ['SuperAdmin'],
        },
        component: AddApplicationUserComponent
      },
      {
        path: 'edit-application-user/:Id',
        canActivate: [AuthGuard],
        data: {
          roles: ['SuperAdmin'],
        },
        component: EditApplicationUserComponent
      },
      {
        path: 'add-application-role',
        canActivate: [AuthGuard],
        data: {
          roles: ['SuperAdmin'],
        },
        component: AddApplicationRoleComponent
      },
      {
        path: 'profile',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: ProfileComponent
      },
      {
        path: 'unauthorized',
        data: {
          roles: ['Everybody'],
        },
        component: UnauthorizedComponent
      },
    ]
  },
  {
    path: '',
    component: LoginLayoutComponent,
    children: [
      {
        path: 'login',
        data: {
          roles: ['Everybody'],
        },
        component: LoginComponent
      },
    ]
  },
];

export const AppRoutes: ModuleWithProviders = RouterModule.forRoot(routes);
