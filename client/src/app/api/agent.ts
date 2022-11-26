import axios, { AxiosError, AxiosResponse } from "axios";
import { request } from "http";
import { toast } from "react-toastify";
import { history } from "../..";
const sleep = () => new Promise(resolve => setTimeout(resolve, 500));
axios.defaults.baseURL = 'http://localhost:5000/api/';

const responseBody = (response: AxiosResponse) => response.data;

axios.interceptors.response.use(async response => {
  await sleep();
  return response
}, (error: AxiosError) => {
  const { data, status } = error.response as any;
  switch (status) {
    case 400:
      if (data.errors) {
        const modelStateErrors: string[] = [];
        for (const key in data.errors) {
          if (data.errors[key]) {
            modelStateErrors.push(data.errors[key])
          }
        }
        throw modelStateErrors.flat();
      }
      toast.error(data.title);
      break;
    case 401:
      toast.error(data.title);
      break;
    case 500:
      history.push(
        {
          pathname: '/server-error',
          state: { error: data }
        }
      );
      break;
    default:
      break;
  }
  return Promise.reject(error.response);
})
const requests = {
  get: (url: string) => axios.get(url).then(responseBody),
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
  delete: (url: string) => axios.delete(url).then(responseBody)
}
const main = {
  Get_Item_By_Id: (id: number, company_id: number) => requests.get(`main/Get_Item_By_Id/${id}/${company_id}`),
  Get_Item_Details: (id: number) => requests.get(`main/Get_Item_Details/${id}`),
  Get_All_Items: (company_id: number) => requests.get(`main/Get_All_Items?Company_Id=${company_id}`),
  Get_All_Companies: () => requests.get("main/Get_All_Companies/"),
  Get_Company_Details: (company_id: number) => requests.get(`main/Get_Company_Details/${company_id}`),
  Get_Company_Unique_Filters: (company_id: number) => requests.get(`main/Get_Company_Unique_Filters/${company_id}`)
}

const TestErrors = {
  get400error: () => requests.get(`buggy/bad-request`),
  get401error: () => requests.get(`buggy/unauthorized`),
  get404error: () => requests.get(`buggy/not-found`),
  get500error: () => requests.get(`buggy/server-error`),
  getValidatioError: () => requests.get(`buggy/validation-error`)
}
const agent = {
  main,
  TestErrors
}

export default agent;