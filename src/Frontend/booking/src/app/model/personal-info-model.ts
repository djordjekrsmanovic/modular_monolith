export class UserPersonalInfo {
    constructor(
      public id:string='',
      public firstName: string = '',
      public lastName: string = '',
      public email: string = '',
      public phone: string = '',
      public address:string='',
    ) {}
}

export class ChangePersonalInfo {
  constructor(
    public id: string='',
    public firstName: string = '',
    public lastName: string = '',
    public email: string = '',
    public phone: string = '',
    public country:string='',
    public city:string='',
    public street:string='',
    public newPassword:string='',
    public previousPassword:string=''
  ) {}
}