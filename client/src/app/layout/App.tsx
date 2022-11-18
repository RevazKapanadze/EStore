
import { Container, createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { blue } from "@mui/material/colors";
import { Route, Routes } from "react-router-dom";
import AboutPage from "../../features/about/AboutPage";
import Catalog from "../../features/catalog/catalog";
import ItemDetails from "../../features/catalog/itemDetailsPage";
import CompaniesPage from "../../features/companies/CompaniesPage";
import HomePage from "../../features/home/HomePage";
import Header from "./Header";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import ServerError from "../errors/serverError";
import NotFound from "../errors/notFound";


function App() {
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
          <Route element={<NotFound/>} />
        </Route>
        <Route path='' element={<CompaniesPage />}> </Route>
        <Route path='/homepage' element={<HomePage />}> </Route>
        <Route path='/server-error' element={<ServerError />}> </Route>
      </Routes>
    </ThemeProvider >

  )
}
export default App;



