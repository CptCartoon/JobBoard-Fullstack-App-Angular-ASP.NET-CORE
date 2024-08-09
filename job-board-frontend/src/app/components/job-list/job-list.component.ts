import { Component } from '@angular/core';
import { JobItemComponent } from './job-item/job-item.component';

@Component({
  selector: 'app-job-list',
  standalone: true,
  imports: [JobItemComponent],
  templateUrl: './job-list.component.html',
  styleUrl: './job-list.component.scss',
})
export class JobListComponent {}
