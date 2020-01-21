export class PaginationModel {
    constructor(public currentPage: number = 1,
                public lastPage: number = null,
                public recordPerPage: number = 10,
                public recordPerPageName: string = '10',
                public total: number = null,
                public list: any = [],
                public from: number = 1,
                public to: number = 1) {
    }
}
