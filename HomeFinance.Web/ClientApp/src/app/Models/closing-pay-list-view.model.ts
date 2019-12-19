export class ClosingPayListData {	
    id: number;
    payDate: Date;
	storeName: string;
	amount: number;
    note: string;
    closingDate: Date;
}

export class ClosingPayListView {	
    rowCount: number;
    closingPayListData: ClosingPayListData[];
}