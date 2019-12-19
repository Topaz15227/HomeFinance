export class ClosingListData {	
    id: number;
    cardName: string;
    closingDate: Date;	
    closingAmount: number;
	closingName: string;
}

export class ClosingView {	
    rowCount: number;
    closingListData: ClosingListData[];
}