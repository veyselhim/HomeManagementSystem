
export interface Bill{
    id:number,
    userId:number,
    type:string,
    invoiceDate: Date,
    amount:number,
    status:boolean
}