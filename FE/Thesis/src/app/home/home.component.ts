import { Component, OnInit } from '@angular/core';

import { AgGridAngular } from 'ag-grid-angular';
import {
  ColDef,
  GridReadyEvent,
  ICellRendererParams,
  IDatasource,
  IGetRowsParams,
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
  // template: `
  //   <div class="content">
  //     <!-- The AG Grid component, with Dimensions, CSS Theme, Row Data, and Column Definition -->
  //     <ag-grid-angular
  //       style="height: 500px;"
  //       [columnDefs]="videoCardColDefs"
  //       [defaultColDef]="defaultColDef"
  //       [rowBuffer]="rowBuffer"
  //       [rowSelection]="rowSelection"
  //       [rowModelType]="rowModelType"
  //       [cacheBlockSize]="cacheBlockSize"
  //       [cacheOverflowSize]="cacheOverflowSize"
  //       [maxConcurrentDatasourceRequests]="maxConcurrentDatasourceRequests"
  //       [infiniteInitialRowCount]="infiniteInitialRowCount"
  //       [maxBlocksInCache]="maxBlocksInCache"
  //       [rowData]="rowData"
  //       [class]="themeClass"
  //       (gridReady)="onGridReady($event)"
  //       >
  //     </ag-grid-angular>
  //   </div>
  // `,
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
    { field: "powerSupply", headerName: "Power Supply", flex: 1 },
    { field: "memory", headerName: "Memory", flex: 1 },
    { field: "processor", headerName: "Processor", flex: 2 },
    { field: "usb", headerName: "USB", flex: 3 },
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


    // this.computerService.getComputers()
    //   .subscribe((data) => {
    //     const dataSource: IDatasource = {
    //       rowCount: undefined,
    //       getRows: (params: IGetRowsParams) => {
    //         console.log(
    //           'asking for ' + params.startRow + ' to ' + params.endRow
    //         );
    //         setTimeout(() => {
    //           // take a slice of the total rows
    //           const rowsThisPage = data.slice(params.startRow, params.endRow);
    //           // if on or after the last page, work out the last row.
    //           let lastRow = -1;
    //           if (data.length <= params.endRow) {
    //             lastRow = data.length;
    //           }
    //           // call the success callback
    //           params.successCallback(rowsThisPage, lastRow);
    //         }, 500);
    //       },
    //     };
    //     params.api!.setGridOption('datasource', dataSource);
    //   });
    }

    populateGrid() {
      this.computerService.getComputers().subscribe((data) => (this.rowData = data));
    }
}
