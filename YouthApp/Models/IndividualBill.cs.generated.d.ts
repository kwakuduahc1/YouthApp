declare module Server.Dtos {
	interface IndividualBills {
		individualBillsID: number;
		studentsID: any;
		amount: number;
		termsID: any;
		isPaid: boolean;
		dateBilled: Date;
		concurrency: any[];
		students: {
			studentsID: any;
			uniqueID: string;
			surname: string;
			classesID: number;
			otherNames: string;
			dateOfBirth: Date;
			dateRegistered: Date;
			concurrency: any[];
			studentsInfo: {
				studentsID: any;
				mother: string;
				father: string;
				placeOfBirth: string;
				concurrency: any[];
				students: any;
			};
			classes: {
				classesID: number;
				className: string;
				isActive: boolean;
				concurrency: any[];
				students: any[];
				classBills: any[];
			};
			payments: any[];
			individualBills: Server.Dtos.IndividualBills[];
		};
	}
}
