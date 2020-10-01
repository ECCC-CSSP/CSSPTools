import { MapInfoWindow, MapMarker, GoogleMap } from '@angular/google-maps'
import { ViewChild, Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { ShellService } from 'src/app/pages/shell';
import { MapModel, MapService } from '.';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MapComponent implements OnInit, OnDestroy {
  @ViewChild(GoogleMap, { static: false }) map: GoogleMap;
  @ViewChild(MapInfoWindow, { static: false }) info: MapInfoWindow;

  // zoom = 15;
  // center: google.maps.LatLngLiteral;
  // options: google.maps.MapOptions = {
  //   //zoomControl: true,
  //   //scrollwheel: true,
  //   //disableDoubleClickZoom: false,
  //   mapTypeId: google.maps.MapTypeId.SATELLITE,
  //   // maxZoom: 15,
  //   // minZoom: 8,
  // };
  // markers = [];
  // polygons = [];
  // polylines = [];
  // infoContent = '';

  constructor(public mapService: MapService, public shellService: ShellService) {
    
  }

  ngOnInit() {
    //    this.center = <google.maps.LatLngLiteral> { 
    //      lat: 46.0915449,
    //      lng: -64.7242012,
    //  };

    //  this.options = <google.maps.MapOptions> {
    //   //zoomControl: true,
    //   //scrollwheel: true,
    //   //disableDoubleClickZoom: false,
    //   mapTypeId: 'satellite', // this.shellService.ShellModel$?.getValue().SatelliteVisible ? google.maps.MapTypeId.SATELLITE : google.maps.MapTypeId.ROADMAP,
    //   // maxZoom: 15,
    //   // minZoom: 8,
    // };
    }

  ngOnDestroy() {

  }

  // zoomIn() {
  //   if (this.zoom < this.options.maxZoom) this.zoom++;
  // }

  // zoomOut() {
  //   if (this.zoom > this.options.minZoom) this.zoom--;
  // }

  click(event: google.maps.MouseEvent) {
    console.log(event);
  }

  // logCenter() {
  //   console.log(JSON.stringify(this.map.getCenter()));
  // }

  // addMarker() {
  //   let marker: google.maps.Marker = new google.maps.Marker({
      
  //   });
  //   this.markers.push({
  //     position: {
  //       lat: this.center.lat + ((Math.random() - 0.5)) / 40,
  //       lng: this.center.lng + ((Math.random() - 0.5)) / 40,
  //     },
  //     label: {
  //       color: 'red',
  //       text: 'Marker label ' + (this.markers.length + 1),
  //     },
  //     title: 'Marker title ' + (this.markers.length + 1),
  //     info: 'Marker info ' + (this.markers.length + 1),
  //     options: {
  //       //animation: google.maps.Animation.BOUNCE,
  //     },
  //   });
  // }

  openInfo(marker: any, content) {
    this.mapService.UpdateMapModel(<MapModel>{ infoContent: content });
    this.info.open(marker);
  }
}
