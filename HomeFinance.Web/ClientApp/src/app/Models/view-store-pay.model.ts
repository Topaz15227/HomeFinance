export class ViewStorePay {	
    id: number;
    cardName: string;
    payDate: Date;
	storeName: string;
	amount: number;
    note: string;
	closingDate?: Date;
    active: boolean;
	cardId: number;
	storeId: number;
	closingId?: number;	
}