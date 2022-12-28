import { createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import agent from "../../app/api/agent";
import { Item, ItemParams } from "../../app/models/item";
import { MetaData } from "../../app/models/pagination";
import { UniqueFilters } from "../../app/models/uniqueFilters";
import { RootState } from "../../app/store/configureStore";
interface CatalogState {
  productsLoaded: boolean;
  filterLoaded: boolean;
  status: string;
  category_Id: string[];
  color: string[];
  main_Category: string[];
  size: string[];
  productParams: ItemParams;
  metaData: MetaData | null;
}

const productsAdapter = createEntityAdapter<Item>();
function getAxiosParams(productParams: ItemParams) {
  const params = new URLSearchParams();
  params.append('pageNumber', productParams.pageNumber.toString());
  params.append('pageSize', productParams.pageSize.toString());
  params.append('orderBy', productParams.orderBy.toString());
  if (productParams.searchTerm) params.append('searchTerm', productParams.searchTerm);
  if (productParams.category_Id) params.append('category_Id', productParams.category_Id.toString());
  if (productParams.color) params.append('color', productParams.color.toString());
  if (productParams.main_Category) params.append('main_Category', productParams.main_Category.toString());
  if (productParams.size) params.append('size', productParams.size.toString());
  return params;
}
export const fetchProductsAsync = createAsyncThunk<Item[], { company_id: string }, { state: RootState }>(
  'catalog/fetchProductsAsync',
  async ({ company_id }, thunkApi) => {
    const params = getAxiosParams(thunkApi.getState().catalog.productParams);
    try {
      const response = await agent.main.Get_All_Items(parseInt(company_id), params);
      thunkApi.dispatch(setMetaData(response.metaData));
      return response.items;
    } catch (error) {

    }
  }
)
export const fetchProductByIdAsync = createAsyncThunk<Item[], { id: string }>(
  'catalog/fetchProductsAsync',
  async ({ id }) => {
    try {
      return await agent.main.Get_Item_Details(parseInt(id));
    } catch (error) {

    }
  }
)
export const fetchFilters = createAsyncThunk<UniqueFilters, { company_id: string }>(
  'catalog/fetchFilters',
  async ({ company_id }) => {
    try {
      return agent.main.Get_Company_Unique_Filters(parseInt(company_id));
    } catch (error) {

    }
  }
)
function initParams() {
  return {
    pageNumber: 1,
    pageSize: 20,
    orderBy: 'name'
  }
}
export const catalogSlice = createSlice({
  name: 'catalog',
  initialState: productsAdapter.getInitialState<CatalogState>({
    productsLoaded: false,
    filterLoaded: false,
    status: 'idle',
    category_Id: [],
    main_Category: [],
    size: [],
    color: [],
    productParams: initParams(),
    metaData: null

  }),
  reducers: {
    setProductParams: (state, action) => {
      state.productsLoaded = false;
      state.productParams = { ...state.productParams, ...action.payload, pageNumber: 1 };
    },
    setPageNumber: (state, action) => {
      state.productsLoaded = false;
      state.productParams = { ...state.productParams, ...action.payload };
    },
    setMetaData: (state, action) => {
      state.metaData = action.payload;
    },
    resetProductParams: (state) => {
      state.productParams = initParams();
    }
  },
  extraReducers: (builder => {
    builder.addCase(fetchProductsAsync.pending, (state) => {
      state.status = 'pendingFetchProducts';
    });
    builder.addCase(fetchProductsAsync.fulfilled, (state, action) => {
      productsAdapter.setAll(state, action.payload);
      state.status = 'idle';
      state.productsLoaded = true;
    });
    builder.addCase(fetchProductsAsync.rejected, (state) => {
      state.status = 'idle'
    });
    builder.addCase(fetchFilters.pending, (state) => {
      state.status = 'pendingFetchFilters';
    });
    builder.addCase(fetchFilters.fulfilled, (state, action) => {
      state.category_Id = action.payload.category_Id;
      state.main_Category = action.payload.main_Category;
      state.size = action.payload.size;
      state.color = action.payload.colour;
      state.filterLoaded = true;
    });
    builder.addCase(fetchFilters.rejected, (state, action) => {
      state.status = 'idle';
      console.log(action.payload);
    });
  })
})
export const productSelectors = productsAdapter.getSelectors((state: RootState) => state.catalog);
export const { setProductParams, resetProductParams, setMetaData, setPageNumber } = catalogSlice.actions;