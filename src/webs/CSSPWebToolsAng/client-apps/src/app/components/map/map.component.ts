import { MapInfoWindow, MapMarker, GoogleMap } from '@angular/google-maps'
import { ViewChild, Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { MapService } from '.';
import { AppVar } from '../../app.model';
import { AppService } from '../../app.service';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MapComponent implements OnInit, OnDestroy {
  @Input() AppVar: AppVar;
  @ViewChild("map", { static: true }) mapElement: any;
  map: any;
  latitude: number;
  longitude: number;
  coordinates = [];

  constructor(public mapService: MapService, public appService: AppService) {
    
  }

  ngOnInit() {
    const mapProperties = {
      center: new google.maps.LatLng(-33.8569, 151.2152),
      zoom: 11,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    this.map = new google.maps.Map(
      this.mapElement.nativeElement,
      mapProperties
    );
  }

  ngOnDestroy()
  {

  }
  onAdd() {
    var stringToJson = JSON.parse(
      '{"lat":' + this.latitude + "," + '"lng":' + this.longitude + "}"
    );
    this.coordinates.push(stringToJson);
    this.latitude = null;
    this.longitude = null;
  }

  onSubmit() {
    const polygon = new google.maps.Polygon({
      paths: this.coordinates,
      strokeColor: "#FF0000",
      strokeOpacity: 0.8,
      strokeWeight: 2,
      fillColor: "#FF0000",
      fillOpacity: 0.35
    });
    polygon.setMap(this.map);

    // Create the bounds object
    var bounds = new google.maps.LatLngBounds();

    // Get paths from polygon and set event listeners for each path separately
    polygon.getPath().forEach(function(path, index) {
      bounds.extend(path);
    });
    console.log(bounds);

    // Fit Polygon path bounds
    this.map.fitBounds(bounds);
  }












  // @ViewChild(GoogleMap, { static: false }) map: GoogleMap;
  // @ViewChild(MapInfoWindow, { static: false }) info: MapInfoWindow;

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

  // constructor(public mapService: MapService, public shellService: ShellService) {
    
  // }

  // ngOnInit() {
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
  //   }

  // ngOnDestroy() {

  // }

  // zoomIn() {
  //   if (this.zoom < this.options.maxZoom) this.zoom++;
  // }

  // zoomOut() {
  //   if (this.zoom > this.options.minZoom) this.zoom--;
  // }

  // click(event: google.maps.MouseEvent) {
  //   console.log(event);
  // }

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

  // openInfo(marker: any, content) {
  //   this.mapService.UpdateMapModel(<MapModel>{ infoContent: content });
  //   this.info.open(marker);
  // }
}
