import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VideoCardDetailsComponent } from './video-card-details.component';

describe('VideoCardDetailsComponent', () => {
  let component: VideoCardDetailsComponent;
  let fixture: ComponentFixture<VideoCardDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [VideoCardDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VideoCardDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
