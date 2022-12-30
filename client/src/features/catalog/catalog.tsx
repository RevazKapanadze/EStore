import { Container, Grid, Paper, Typography } from "@mui/material";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import AppPagination from "../../app/components/appPagination";
import CheckBoxButtons from "../../app/components/checkBoxButtons";
import RadioButtonGroup from "../../app/components/radioButtonGroup";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { fetchFilters, fetchProductsAsync, productSelectors, setPageNumber, setProductParams } from "./catalogSlice";
import ItemList from "./itemList";
import ProductSearch from "./productSearch";


const sortOptions = [
  { value: 'name', label: 'ბოლოს დამატებული' },
  { value: 'priceDesc', label: 'ფასი - მაღლიდან დაბლა' },
  { value: 'price', label: 'ფასი - დაბლიდან მაღლა' }
]
export default function Catalog() {
  const { company_id } = useParams<{ company_id: string }>();
  const items = useAppSelector(productSelectors.selectAll);
  const dispatch = useAppDispatch();
  const { productsLoaded, filterLoaded, category_Id, main_Category, size, color, productParams, metaData } = useAppSelector(state => state.catalog);

  useEffect(() => {
    if (!productsLoaded) dispatch(fetchProductsAsync({ company_id: company_id! }));
  }, [company_id, productsLoaded, dispatch,])

  useEffect(() => {
    if (!filterLoaded) dispatch(fetchFilters({ company_id: company_id! }));
  }, [company_id, dispatch, filterLoaded])

  if (!items.length) return <h3> პროდუქტი არ მოიძებნა</h3>
  if (!filterLoaded) return <LoadingComponent message='პროდუქტები იტვირთება, გთხოვთ დაელოდოთ' />
  return (

    <Container sx={{ marginLeft: 20, marginRight: 20 }} maxWidth="xl" >
      <Grid container spacing={4} >
        <Grid item xs={3}>
          <Paper sx={{ mb: 2 }}>
            <ProductSearch />
          </Paper>
          <Paper sx={{ mb: 2, p: 2 }}>
            <RadioButtonGroup selectedValue={productParams.orderBy} options={sortOptions}
              onChange={(e) => dispatch(setProductParams({ orderBy: e.target.value }))} />
          </Paper>
          <Paper>
            <Typography align="center">კატეგორია</Typography>
            <CheckBoxButtons
              items={category_Id}
              checked={productParams.category_Id!}
              onChange={(items: string[]) => dispatch(setProductParams({ category_Id: items }))} />
          </Paper>
          <Paper>
            <Typography align="center">მთავარი კატეგორია</Typography>
            <CheckBoxButtons
              items={main_Category}
              checked={productParams.main_Category!}
              onChange={(items: string[]) => dispatch(setProductParams({ main_Category: items }))} />
          </Paper>
          {productParams.size &&
            <Paper>
              <Typography align="center">ზომა</Typography>
              <CheckBoxButtons
                items={size}
                checked={productParams.size!}
                onChange={(items: string[]) => dispatch(setProductParams({ size: items }))} />
            </Paper>}
          {productParams.color &&
            <Paper>
              <Typography align="center">ფერი</Typography>
              <CheckBoxButtons
                items={color}
                checked={productParams.color!}
                onChange={(items: string[]) => dispatch(setProductParams({ color: items }))} />
            </Paper>}
        </Grid>
        <Grid item xs={9}>
          <ItemList items={items} />
        </Grid>
        <Grid sx={{ paddingTop: 5, marginLeft: 75 }} >
          {metaData && 
            < AppPagination metaData={metaData}
              onChangePage={(page: number) => dispatch(setPageNumber({ pageNumber: page }))} />
          }
        </Grid>
      </Grid>
    </Container >
  )
}