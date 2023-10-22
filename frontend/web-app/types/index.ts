export type PagedResult<T> = {
    result: T[],
    pageCount: number,
    totalCount: number
}

export type Auction = {
    createdAt: string
    updatedAt: string
    auctionEnd: string
    seller: string
    winner?: string
    make: string
    model: string
    year: number
    color: string
    mileage: number
    imageUrl: string
    status: string
    reservePrice: number
    soldAmount: number
    currentHighBid: number
    id: string
}