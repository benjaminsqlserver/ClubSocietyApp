import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject, throwError } from 'rxjs';

import { ConfigService } from './config.service';
import { ODataClient } from './odata-client';
import * as models from './con-data.model';

@Injectable()
export class ConDataService {
  odata: ODataClient;
  basePath: string;

  constructor(private http: HttpClient, private config: ConfigService) {
    this.basePath = config.get('conData');
    this.odata = new ODataClient(this.http, this.basePath, { legacy: false, withCredentials: true });
  }

  getContributionsViews(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/ContributionsViews`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getGenders(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Genders`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createGender(expand: string | null, gender: models.Gender | null) : Observable<any> {
    return this.odata.post(`/Genders`, gender, { expand }, []);
  }

  deleteGender(genderId: number | null) : Observable<any> {
    return this.odata.delete(`/Genders(${genderId})`, item => !(item.GenderID == genderId));
  }

  getGenderByGenderId(expand: string | null, genderId: number | null) : Observable<any> {
    return this.odata.getById(`/Genders(${genderId})`, { expand });
  }

  updateGender(expand: string | null, genderId: number | null, gender: models.Gender | null) : Observable<any> {
    return this.odata.patch(`/Genders(${genderId})`, gender, item => item.GenderID == genderId, { expand }, []);
  }

  getMembers(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Members`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createMember(expand: string | null, member: models.Member | null) : Observable<any> {
    return this.odata.post(`/Members`, member, { expand }, ['Gender', 'MemberPosition']);
  }

  deleteMember(memberId: number | null) : Observable<any> {
    return this.odata.delete(`/Members(${memberId})`, item => !(item.MemberID == memberId));
  }

  getMemberByMemberId(expand: string | null, memberId: number | null) : Observable<any> {
    return this.odata.getById(`/Members(${memberId})`, { expand });
  }

  updateMember(expand: string | null, memberId: number | null, member: models.Member | null) : Observable<any> {
    return this.odata.patch(`/Members(${memberId})`, member, item => item.MemberID == memberId, { expand }, ['Gender','MemberPosition']);
  }

  getMemberContributions(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/MemberContributions`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createMemberContribution(expand: string | null, memberContribution: models.MemberContribution | null) : Observable<any> {
    return this.odata.post(`/MemberContributions`, memberContribution, { expand }, ['Member']);
  }

  deleteMemberContribution(contributionId: number | null) : Observable<any> {
    return this.odata.delete(`/MemberContributions(${contributionId})`, item => !(item.ContributionID == contributionId));
  }

  getMemberContributionByContributionId(expand: string | null, contributionId: number | null) : Observable<any> {
    return this.odata.getById(`/MemberContributions(${contributionId})`, { expand });
  }

  updateMemberContribution(expand: string | null, contributionId: number | null, memberContribution: models.MemberContribution | null) : Observable<any> {
    return this.odata.patch(`/MemberContributions(${contributionId})`, memberContribution, item => item.ContributionID == contributionId, { expand }, ['Member']);
  }

  getMemberListProcs(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/MemberListProcsFunc()`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getMemberPositions(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/MemberPositions`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createMemberPosition(expand: string | null, memberPosition: models.MemberPosition | null) : Observable<any> {
    return this.odata.post(`/MemberPositions`, memberPosition, { expand }, []);
  }

  deleteMemberPosition(positionId: number | null) : Observable<any> {
    return this.odata.delete(`/MemberPositions(${positionId})`, item => !(item.PositionID == positionId));
  }

  getMemberPositionByPositionId(expand: string | null, positionId: number | null) : Observable<any> {
    return this.odata.getById(`/MemberPositions(${positionId})`, { expand });
  }

  updateMemberPosition(expand: string | null, positionId: number | null, memberPosition: models.MemberPosition | null) : Observable<any> {
    return this.odata.patch(`/MemberPositions(${positionId})`, memberPosition, item => item.PositionID == positionId, { expand }, []);
  }
}
