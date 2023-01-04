export interface ShippingAdress {
  fullName: string;
  adress1: string;
  google_Map: string;
  city: string;
  state: string;
  phone_Number: string;
  eMail: string;
}

export interface OrderItem {
  itemId: number;
  name: string;
  pictureUrl: string;
  price: number;
  quantity: number;
}

export interface Order {
  id: number;
  company_Id: number;
  company?: any;
  buyerId: string;
  shippingAdress: ShippingAdress;
  orderDate: string;
  orderItems: OrderItem[];
  subTotal: number;
  deliveryFee: number;
  orderStatus: string;
  total: number;
}