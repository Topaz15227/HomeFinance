export class ArchiveListData {	
    id: number;
    cardName: string;
    payDate: Date;
	storeName: string;
	amount: number;
    note: string;
    closingDate: Date;
	closingId: number;
}

export class ArchiveListView {	
    rowCount: number;
    archiveListData: ArchiveListData[];
}