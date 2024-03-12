import { Component, OnInit } from '@angular/core';

import { MessageService } from '../services/message.service';
import { VideoCardService } from '../services/video-card.service';
import { IVideoCard } from '../interfaces/video-card';

@Component({
  selector: 'app-video-card',
  templateUrl: './video-card.component.html',
  styleUrl: './video-card.component.css'
})
export class VideoCardComponent implements OnInit {

  videoCards: IVideoCard[] = [];

  constructor(
    private messageService: MessageService,
    private videoCardService: VideoCardService
  ) {};

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): void {
    this.videoCardService.getVideoCards()
      .subscribe(vcs => this.videoCards = vcs);
  }

  add(videoCardDesc: string): void {
    videoCardDesc = videoCardDesc.trim();
    if (!videoCardDesc) { return };

    this.videoCardService.addVideoCard({ videoCardDesc } as IVideoCard)
      .subscribe(() => this.getAll());
  }

  delete(id: number): void {
    this.videoCardService.deleteVideoCard(id)
      .subscribe(() => this.getAll());
  }
}
