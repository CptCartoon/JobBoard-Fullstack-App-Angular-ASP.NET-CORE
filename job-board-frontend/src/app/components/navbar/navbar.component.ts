import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MobileMenuComponent } from './mobile-menu/mobile-menu.component';
import { BtnComponent } from '../shared/btn/btn.component';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, MobileMenuComponent, BtnComponent],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {
  showMenu: boolean = false;

  openMenu() {
    this.showMenu = !this.showMenu;
  }
}
