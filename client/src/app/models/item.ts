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
export interface ItemParams {
  orderBy: string;
  searchTerm?: string;
  main_Category?: string[];
  category_Id?: string[];
  color?: string[];
  size?: string[];
  pageNumber: number;
  pageSize: number;
}