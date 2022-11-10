export interface Item {
  id: number;
  short_Name: string;
  short_Description: string;
  price: number;
  quantity: number;
  main_Category: number;
  is_Active: number;
  main_Photo?: any;
  category_Id: number;
  company_Id: number;
}