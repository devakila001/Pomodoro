import { Entry } from "./Entry";
export interface User {
  userId: number;
  userName: string;
  entries: Entry[];
}
