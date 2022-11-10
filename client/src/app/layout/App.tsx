import { Container, createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { blue, blueGrey, red } from "@mui/material/colors";
import Catalog from "../../features/catalog/catalog";
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
      <Header />
      <Container>
        <Catalog />
      </Container>
    </ThemeProvider>
  )
}
export default App;


