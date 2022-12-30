import { createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { blue } from "@mui/material/colors";
import { Route, Routes } from "react-router-dom";
import AboutPage from "../../features/about/AboutPage";
import Catalog from "../../features/catalog/catalog";
import ItemDetails from "../../features/catalog/itemDetailsPage";
import CompaniesPage from "../../features/companies/CompaniesPage";
import HomePage from "../../features/home/HomePage";
import Header from "./Header";
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import ServerError from "../errors/serverError";
import NotFound from "../errors/notFound";
import BasketPage from "../../features/basket/basketPage";
import { useCallback, useEffect, useState } from "react";
import LoadingComponent from "./LoadingComponent";
import CheckoutPage from "../../features/checkout/checkoutPage";
import Login from "../../features/account/login";
import Register from "../../features/account/register";
import { useAppDispatch } from "../store/configureStore";
import { fetchCurrentUser } from "../../features/account/accountSlice";
import { fetchBasketAsync } from "../../features/basket/basketSlice";
import { PrivateRoute } from "./PrivateRoute";
import EmptyBasketPage from "../../features/basket/emptyBasketPage";
import AdminPanel from "../../features/adminPanel/adminPanel";



function App() {
  const dispatch = useAppDispatch();
  const [loading, setLoading] = useState(true);

  const initApp = useCallback(async () => {
    try {
      await dispatch(fetchCurrentUser());
      await dispatch(fetchBasketAsync());
    } catch (error) {
      console.log(error);
    }
  }, [dispatch])
  useEffect(() => {
    initApp().then(() => setLoading(false));
  }, [initApp])


  if (loading) return <LoadingComponent message='პროდუქტები იტვირთება, გთხოვთ დაელოდოთ' />

  const theme = createTheme({
    palette: {
      primary: blue,
    },
  });
  return (
    <ThemeProvider theme={theme}>
      <ToastContainer position='bottom-right' hideProgressBar />
      <CssBaseline />
      <Routes>
        <Route path='/:company_id' element={<Header />}>
          <Route path='' element={<Catalog />}> </Route>
          <Route path=':id' element={<ItemDetails />} />
          <Route path='about' element={<AboutPage />} />
          <Route path='adminpanel' element={<AdminPanel />} />
          <Route element={<NotFound />} />
          <Route element={<EmptyBasketPage />} />
          <Route path='basket' element={<BasketPage />} />
          <Route path='login' element={<Login />} />
          <Route path='register' element={<Register />} />
          <Route element={<PrivateRoute />}>
            <Route path="checkout" element={<CheckoutPage />} />
          </Route>
        </Route>
        <Route path='' element={<CompaniesPage />}> </Route>
        <Route path='/homepage' element={<HomePage />}> </Route>
        <Route path='/server-error' element={<ServerError />}> </Route>
      </Routes>

    </ThemeProvider >
  )
}
export default App;



