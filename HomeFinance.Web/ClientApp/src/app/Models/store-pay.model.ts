export class StorePay {	
    id: number;
    payDate: Date;	
	cardId: number;
	storeId: number;
	amount: number;
	note?: string;
	closingId?: number;	
    active: boolean;
}