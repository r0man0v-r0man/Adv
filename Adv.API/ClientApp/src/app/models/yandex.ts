export interface GeoObjectCollection {
  metaDataProperty: GeocoderResponseMetaData;
  featureMember: GeoObject[];
}
export interface GeoObject {
  metaDataProperty: GeocoderMetaData;
  description: string;
  name: string;
  boundedBy: Envelope;
  point: Point;
}
export interface GeocoderMetaData {
  kind: string;
  text: string;
  precision: string;
  address: Address;
}
export interface Address {
  country_code: string;
  postal_code: string;
  formatted: string;
  components: AddressComponent[];
}
export interface AddressComponent {
  kind: string;
  name: string;
}
export interface Envelope {
  lowerCorner: string;
  upperCorner: string;
}
export interface Point {
  pos: string;
}
export interface GeocoderResponseMetaData {
  request: string;
  found: number;
  results: number;
}

