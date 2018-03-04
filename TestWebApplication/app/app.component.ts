import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    styleUrls: ['./app.component.css'],
    template: `<h1>Добро пожаловать {{name}}!</h1>
                <label>Введите имя:</label>
                <input [(ngModel)]="name" placeholder="name">`
})
export class AppComponent {
    name = '';
}