import { HttpErrorResponse } from "@angular/common/http";

export interface IHttpHelper<T> {
    processing: boolean;
    error: boolean;
    message: string;
    onDelete(item: T): void;
    onError(err: HttpErrorResponse): void;
    onSuccess(item: T): void;
}
