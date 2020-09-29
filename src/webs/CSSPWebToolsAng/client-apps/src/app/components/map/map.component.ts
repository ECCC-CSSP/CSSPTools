import { MapInfoWindow, MapMarker, GoogleMap } from '@angular/google-maps'
import { ViewChild, Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MapComponent implements OnInit, OnDestroy {
  @ViewChild(GoogleMap, { static: false }) map: GoogleMap
  @ViewChild(MapInfoWindow, { static: false }) info: MapInfoWindow

  zoom = 15;
  center: google.maps.LatLngLiteral;
  options: google.maps.MapOptions = {
    //zoomControl: true,
    //scrollwheel: true,
    //disableDoubleClickZoom: false,
    mapTypeId: 'satellite',
    // maxZoom: 15,
    // minZoom: 8,
  };
  markers = [];
  infoContent = '';

  ngOnInit() {
    // navigator.geolocation.getCurrentPosition((position) => {
    //   this.center = {
    //     lat: 46.0915449, //position.coords.latitude,
    //     lng: -64.7242012, //position.coords.longitude,
    //   }

       this.center = <google.maps.LatLngLiteral> { 
         lat: 46.0915449,
         lng: -64.7242012,
     };
  }

  ngOnDestroy() {

  }

  zoomIn() {
    if (this.zoom < this.options.maxZoom) this.zoom++;
  }

  zoomOut() {
    if (this.zoom > this.options.minZoom) this.zoom--;
  }

  click(event: google.maps.MouseEvent) {
    console.log(event);
  }

  logCenter() {
    console.log(JSON.stringify(this.map.getCenter()));
  }

  addMarker() {
    let marker: google.maps.Marker = new google.maps.Marker({
      
    });
    this.markers.push({
      position: {
        lat: this.center.lat + ((Math.random() - 0.5)) / 40,
        lng: this.center.lng + ((Math.random() - 0.5)) / 40,
      },
      label: {
        color: 'red',
        text: 'Marker label ' + (this.markers.length + 1),
      },
      title: 'Marker title ' + (this.markers.length + 1),
      info: 'Marker info ' + (this.markers.length + 1),
      options: {
        //animation: google.maps.Animation.BOUNCE,
      },
    });
  }

  openInfo(marker: MapMarker, content) {
    this.infoContent = content;
    this.info.open(marker);
  }
}
