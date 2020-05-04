import { Component, OnInit } from '@angular/core';
import { Engine } from '../../../core/model/engine';
import { EngineService } from '../../../core/services/Engine.service';

@Component({
  selector: 'app-vehicle-overview',
  templateUrl: './vehicle-overview.component.html',
  styleUrls: ['./vehicle-overview.component.css']
})
export class VehicleOverviewComponent implements OnInit {

  vehicles: Engine[];

  constructor(private engineService: EngineService) { }

  ngOnInit() {
    this.engineService.requestAllEngines().subscribe((data: Engine[]) => {
      this.vehicles = data;
    });

  }
}
