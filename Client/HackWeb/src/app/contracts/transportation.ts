import { Vehicle } from "./vehicle";

export class Transportation {
    id: string;
    transportationDateTime: Date;
    distance: number;
    totalCarbonFootprint: number;
    vehicle : Vehicle;
    createdAt: Date;
}