import { Injectable } from '@angular/core';
import { BookDetail } from './book-detail.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class BookDetailService {

  constructor(private http: HttpClient) { }

  readonly baseURL = 'http://localhost:61236/api/Book'
  formData: BookDetail = new BookDetail();
  list: BookDetail[];

  postBookDetail() {
    return this.http.post(this.baseURL, this.formData);
  }

  putBookDetail() {
    return this.http.put(`${this.baseURL}/${this.formData.bookId}`, this.formData);
  }

  deleteBookDetail(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList() {
    this.http.get(this.baseURL)
      .toPromise()
      .then(res =>this.list = res as BookDetail[]);
  }


}
