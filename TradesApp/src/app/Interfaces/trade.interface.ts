import { ICounterparty } from "./counterparty.interface";

export interface ITrade {
    id: number;
    counterPartyId: number
    price: number;
    quantity: number;
    direction: number;
    product: string;
    date: string;
    counterParty: ICounterparty;
}