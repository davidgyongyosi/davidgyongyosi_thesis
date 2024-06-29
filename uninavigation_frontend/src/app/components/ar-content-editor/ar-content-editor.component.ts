import { Component, OnInit } from '@angular/core';
import { ArService } from '../../services/ar/ar.service';
import { ArContent } from '../../models/ar_content.model';
import { NzModalService } from 'ng-zorro-antd/modal';
import { ArEditModalComponent } from './ar-edit-modal/ar-edit-modal.component';
import { NotificationService } from '../../services/notification/notification.service';

@Component({
  selector: 'app-ar-content-editor',
  templateUrl: './ar-content-editor.component.html',
  styleUrls: ['./ar-content-editor.component.scss']
})
export class ArContentEditorComponent implements OnInit {
  contents?: Array<ArContent>;
  currentContents?: Array<ArContent>;
  filteredContents?: Array<ArContent>;
  pageIndex: number = 1;
  pageSize: number = 12;
  searchQuery: string = '';

  constructor(private arService: ArService, private modal: NzModalService, private notification: NotificationService) {}

  ngOnInit() {
    this.loadContents();
  }

  loadContents() {
    this.arService.getAllContents().subscribe({
      next: (data) => {
        this.contents = data;
        this.filteredContents = data;
        this.updateCurrentContents();
      },
      error: (e) => {
        this.notification.error(e.error.message);
      }
    });
  }

  updateCurrentContents() {
    const startItem = (this.pageIndex - 1) * this.pageSize;
    const endItem = startItem + this.pageSize;
    this.currentContents = this.filteredContents?.slice(startItem, endItem);
  }

  changePage(pageIndex: number) {
    this.pageIndex = pageIndex;
    this.updateCurrentContents();
  }

  filterContents() {
    this.filteredContents = this.contents?.filter(content =>
      content.roomName.toLowerCase().includes(this.searchQuery.toLowerCase())
    );
    this.pageIndex = 1; // Reset to the first page
    this.updateCurrentContents();
  }

  editContent(content: ArContent) {
    const modalRef = this.modal.create({
      nzTitle: 'Edit Content',
      nzContent: ArEditModalComponent,
      nzFooter: null,
      nzData: {
        data: content,
      },
    });

    const instance = modalRef.getContentComponent();
    instance.onClose.subscribe(() => {
      this.loadContents();
      modalRef.close();
    });
  }

  deleteContent(id: number) {
    this.arService.deleteContent(id).subscribe({
      next: (data) => {
        this.loadContents();
      },
      error: (e) => {
        this.notification.error(e.error.message);
      }
    });
  }
}
