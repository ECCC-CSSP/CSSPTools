import { HttpRequestModel } from 'src/app/models';

export interface MapTextModel extends HttpRequestModel  {
    Title?: string
}

export interface MapModel extends HttpRequestModel {
    zoom: number;
    center: google.maps.LatLngLiteral;
    options: google.maps.MapOptions;
    markerList: [];
    polygonList: [];
    polylineList: [];
    infoContent: string;
}
