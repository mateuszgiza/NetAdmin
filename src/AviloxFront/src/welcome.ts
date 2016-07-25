export class Welcome {
  heading = 'Welcome to Aurelia!';
  firstname = 'John';
  lastname = 'Doe';

  get fullname() {
    return `${this.firstname} ${this.lastname}`;
  }

  submit() {
    alert(`Welcome, ${this.fullname}!`);
  }
}