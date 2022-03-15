export interface ContributionsView {
  ContributionID: number;
  FirstName: string;
  Surname: string;
  ContributionDate: string;
  AmountContributed: number;
}

export interface Gender {
  GenderID: number;
  GenderName: string;
}

export interface Member {
  MemberID: number;
  FirstName: string;
  MiddleName: string;
  Surname: string;
  GenderID: number;
  DateOfBirth: string;
  ResidentialAddress: string;
  OfficeAddress: string;
  MobileNumber1: string;
  WhatsappNumber: string;
  Email: string;
  MemberPhoto: string;
  CurrentPositionID: number;
}

export interface MemberContribution {
  ContributionID: number;
  MemberID: number;
  ContributionDate: string;
  AmountContributed: number;
}

export interface MemberListProc {
  MemberID: number;
  FullName: string;
}

export interface MemberPosition {
  PositionID: number;
  PositionName: string;
}
