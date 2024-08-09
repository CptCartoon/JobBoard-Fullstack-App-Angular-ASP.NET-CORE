import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { BtnComponent } from '../shared/btn/btn.component';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, BtnComponent],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {
  showMenu: boolean = false;

  openMenu() {
    this.showMenu = !this.showMenu;
  }
}
