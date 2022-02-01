import { Component, OnInit } from '@angular/core';
import { BookDetailService } from 'src/app/shared/book-detail.service';
import { NgForm } from '@angular/forms';
import { BookDetail } from 'src/app/shared/book-detail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-book-detail-form',
  templateUrl: './book-detail-form.component.html',
  styles: [
  ]
})
export class BookDetailFormComponent implements OnInit {
// City Names
City: any = ['Florida', 'South Dakota', 'Tennessee', 'Michigan']
  constructor(public service: BookDetailService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.bookId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postBookDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted successfully', 'Book Detail Register')
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putBookDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated successfully', 'Book Detail Register')
      },
      err => { console.log(err); }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new BookDetail();
  }

}
