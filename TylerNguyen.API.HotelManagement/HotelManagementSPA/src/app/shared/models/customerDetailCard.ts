export interface RoomTypes {
    id: number;
    rtdesc: string;
    rent: number;
}

export interface Service {
    id: number;
    roomno?: any;
    sdesc: string;
    amount: number;
    serviceDate: Date;
    rooms?: any;
}

export interface Rooms {
    id: number;
    rtcode: number;
    status: boolean;
    roomTypes: RoomTypes;
    services: Service[];
}

export interface CustomerDetail {
    id: number;
    roomno: number;
    cname: string;
    address: string;
    phone: string;
    email: string;
    checkin: Date;
    totalPERSONS: number;
    bookingDays: number;
    advance: number;
    rooms: Rooms;
}
