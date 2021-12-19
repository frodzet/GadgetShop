export class Login {
  static readonly type = 'login';
  constructor(public username: string, public password: string) {
  }
}
