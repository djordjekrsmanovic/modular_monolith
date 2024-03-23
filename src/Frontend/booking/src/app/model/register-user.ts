export class UserRegistration {
    constructor(
      public firstName: string = '',
      public lastName: string = '',
      public email: string = '',
      public password: string = '',
      public phone: string = '',
      public type: string = '',
      public street: string = '',
      public country: string = '',
      public city: string = ''
    ) {}
  }