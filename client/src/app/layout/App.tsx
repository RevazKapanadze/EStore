
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
import { useStoreContext } from "../context/storeContext";
import { useEffect, useState } from "react";
import agent from "../api/agent";
import { getCookie } from "../util/util";
import LoadingComponent from "./LoadingComponent";
import CheckoutPage from "../../features/checkout/checkoutPage";


function App() {

  const { setBasket } = useStoreContext();
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const buyerId = getCookie('buyerId');
    if (buyerId) {
      agent.basket.GetBasket()
        .then(basket => setBasket(basket))
        .catch(error => console.log(error))
        .finally(() => setLoading(false))
    } else {
      setLoading(false);
    }
  }, [setBasket])
  if (loading) return <LoadingComponent message='Initialising app...' />

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
          <Route path=':id' element={<ItemDetails />}></Route>
          <Route path='about' element={<AboutPage />}></Route>
          <Route element={<NotFound />} />
          <Route path='basket' element={<BasketPage />}> </Route>
          <Route path='checkout' element={<CheckoutPage />}></Route>
        </Route>
        <Route path='' element={<CompaniesPage />}> </Route>
        <Route path='/homepage' element={<HomePage />}> </Route>
        <Route path='/server-error' element={<ServerError />}> </Route>
      </Routes>
    </ThemeProvider >
  )
}
export default App;



