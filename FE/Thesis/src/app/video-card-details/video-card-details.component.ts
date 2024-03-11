import { Component, Input, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

import { IVideoCard } from '../interfaces/video-card';
import { VideoCardService } from '../services/video-card.service';

@Component({
  selector: 'app-video-card-details',
  templateUrl: './video-card-details.component.html',
  styleUrl: './video-card-details.component.css'
})
export class VideoCardDetailsComponent implements OnInit {
  videoCard: IVideoCard | undefined;

  constructor(
    private route: ActivatedRoute,
    private videoCardService: VideoCardService,
    private location: Location,
  ) {}

  ngOnInit(): void {
    this.getVideoCard();
  }

  getVideoCard(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.videoCardService.getVideoCard(id).subscribe(vc => this.videoCard = vc);
  }

  save(): void {
    if (this.videoCard) {
      this.videoCardService.updateVideoCard(this.videoCard).subscribe(() => this.goBack());
    }
  }

  goBack(): void {
    this.location.back();
  }
}
