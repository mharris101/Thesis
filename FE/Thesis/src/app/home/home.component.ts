import { Component, OnInit } from '@angular/core';

import { AgGridAngular } from 'ag-grid-angular';
import {
  ColDef,
  GridReadyEvent,
  RowModelType,
} from 'ag-grid-community';
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-quartz.css';

import { IComputer } from '../interfaces/computer';
import { MessageService } from '../services/message.service';
import { ComputerService } from '../services/computer.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  constructor(
    private messageService: MessageService,
    private computerService: ComputerService,
  ) {};

  public columnDefs: ColDef<IComputer>[] = [
    { field: "computerId", headerName: "ID", flex: 1 },
    { field: "disk", headerName: "Disk", flex: 1 },
    { field: "videoCard", headerName: "Video Card", flex: 3 },
    { field: "weight", headerName: "Weight", flex: 1},
    { field: "powerSupply", headerName: "Power Supply", flex: 2 },
    { field: "memory", headerName: "Memory", flex: 1 },
    { field: "processor", headerName: "Processor", flex: 3 },
    { field: "usb", headerName: "USB", flex: 4 },
  ];

  public defaultColDef: ColDef = {
    flex: 1,
    minWidth: 100,
    sortable: true,
    filter: true,
    floatingFilter: true,
  };

  public rowBuffer = 0;
  public rowSelection: 'single' | 'multiple' = 'multiple';
  public rowModelType: RowModelType = 'infinite';
  public cacheBlockSize = 100;
  public cacheOverflowSize = 2;
  public maxConcurrentDatasourceRequests = 1;
  public infiniteInitialRowCount = 1000;
  public maxBlocksInCache = 10;
  public rowData!: IComputer[];
  public themeClass: string = "ag-theme-quartz";

  onGridReady(params: GridReadyEvent<IComputer>) {
    this.populateGrid();
  }

  populateGrid() {
    this.computerService.getComputers().subscribe((data) => (this.rowData = data));
  }
}
