import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Entry } from '../../Models/Entry';
import { User } from '../../Models/User';



@Component({
  selector: 'app-pomodoro',
  templateUrl: './pomodoro.component.html',
  styleUrl: './pomodoro.component.css'
})
export class PomodoroComponent {

  public entries: Entry[] = []
  public users: User[] = []
  public storeEntry: Entry = {
      id: 0,
      date: new Date(),
      startingtime: '',
      endingtime: '',
      totaltime: '',
      comment: '',
      userId: 0,
      userName: ''
  }
  timer: any;
  timerStarted: boolean = false;
  startTime!: Date;
  currentTime!: string;
  constructor(private http: HttpClient) { }

  getUsernameFromUserId() {
    if (this.users.length === 0) {
      this.getUser();
      return;
    }

    const selectUser = this.users.find(users => users.userId === +this.storeEntry.userId);
    if (selectUser) {
      this.storeEntry.userName = selectUser.userName;
      console.log(`Username for id ${this.storeEntry.userId} is ${selectUser.userName}`);
    } else {
      console.log(`Sorry did not find user for id ${this.storeEntry.userId}`);
    }
  }

 

  getUser() {
    this.http.get<User[]>('/api/user').subscribe(
      (result) => {
        this.users = result;

      },
      (error) => {
        console.error('Error fetching user:', error);
      }
    );

  }

  ngOnInit(): void {
    this.getAllEntries();
  }

  getAllEntries() {
    this.http.get<Entry[]>('/api/pomodoro').subscribe(
      (result) => {
        this.entries = result;
        this.getUser();
      },
      (error) => {
        console.error('Error fetching entries:', error);
      }
    );
  }



  saveEntry() {
    this.http.post<Entry>('/api/pomodoro', this.storeEntry).subscribe(
      (result) => {
        console.log('saved successfully:', result);
        this.entries.push(result);
        this.getAllEntries();
      },
      (error) => {
        console.error('Error saving entry:', error);
      }
    );
  }

  startTimer() {
    this.storeEntry.startingtime = new Date().toTimeString().slice(0, 8);
    this.startTime = new Date();
    this.timerStarted = true;
    this.timer = setInterval(() => {
      const currentTime = new Date();
      this.currentTime = currentTime.toTimeString().slice(0, 8);
    }, 1000);
  }
   
  stopTimer() {
    clearInterval(this.timer);
    this.timerStarted = false;
    const endTime = new Date();
    const totalTime = this.calculateTotalTime(this.startTime, endTime);
    this.storeEntry.endingtime = endTime.toTimeString().slice(0, 8);
    this.storeEntry.totaltime = totalTime;
    this.getUsernameFromUserId();
    this.saveEntry();
  }

  calculateTotalTime(startTime: Date, endTime: Date): string {
    const totalTimeInSeconds = Math.floor((endTime.getTime() - startTime.getTime()) / 1000);
    const hours = Math.floor(totalTimeInSeconds / 3600);
    const minutes = Math.floor((totalTimeInSeconds % 3600) / 60);
    const seconds = totalTimeInSeconds % 60;
    return `${hours}:${minutes}:${seconds}`;
  }
  title = 'entry.client';
}
