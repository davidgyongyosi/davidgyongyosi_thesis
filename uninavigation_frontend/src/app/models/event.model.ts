import { Location } from "./location.model";

export interface EventList {
  eventId: number;
  name: string;
  startTime: Date;
  endTime: Date;
  location: Location;
  description: string;
  contentType?: string;
  data?: string;
  participantCount: number;
}

export interface EventDetail {
  eventId?: number;
  name?: string;
  startTime?: Date;
  endTime?: Date;
  location?: Location;
  description?: string;
  contentType?: string;
  data?: string;
  participants?: Participant[];
}

export interface Participant {
  userId?: string;
  firstName?: string;
  lastName?: string;
}

export interface CreateEvent {
  name: string;
  startTime: Date;
  endTime: Date;
  location: string;
  description: string;
  picture?: File;
}

export class UpdateEvent {
  name?: string;
  startTime?: Date;
  endTime?: Date;
  location?: string;
  description?: string;
  picture?: File;
}