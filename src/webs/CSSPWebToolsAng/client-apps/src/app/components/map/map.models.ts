import { HttpStatus } from '../../models/HttpStatus.model';

export interface MapVar extends HttpStatus  {
    MapTitle?: string
    zoom?: number;
    center?: google.maps.LatLngLiteral;
    options?: google.maps.MapOptions;
    markerList?: [];
    polygonList?: [];
    polylineList?: [];
    infoContent?: string;
}
