
import { Container, createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { blue } from "@mui/material/colors";
import { Route, Routes } from "react-router-dom";
import AboutPage from "../../features/about/AboutPage";
import Catalog from "../../features/catalog/catalog";
import ItemDetails from "../../features/catalog/itemDetailsPage";
import CompaniesPage from "../../features/companies/CompaniesPage";
import ContactPage from "../../features/contact/ContactPage";
import HomePage from "../../features/home/HomePage";
import Header from "./Header";



function App() {
  const theme = createTheme({
    palette: {
      primary: blue,
    },
  });

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Routes>
        <Route path='/:company_id/catalog/:id' element={<ItemDetails />}></Route>
        <Route path='/:company_id/about' element={<AboutPage />}></Route>
        <Route path='/contact' element={<ContactPage />}> </Route>
        <Route path='/:company_id/catalog' element={<Catalog />}> </Route>
        <Route path='/' element={<CompaniesPage />}> </Route>
      </Routes>
    </ThemeProvider >
  )
}
export default App;



