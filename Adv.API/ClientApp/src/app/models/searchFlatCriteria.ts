export class SearchFlatCriteria{
    rooms: number;
    city: number;
    priceMin: number;
    priceMax: number;
    rentType: number;
    pageNumber: number;
    public constructor(init?: Partial<SearchFlatCriteria>){
        Object.assign(this, init);
    }
}