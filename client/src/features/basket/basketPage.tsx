import { Button, Container, Grid } from "@mui/material";
import BasketSummary from "./basketSummary";
import { Link, useParams } from "react-router-dom";
import { useAppSelector } from "../../app/store/configureStore";
import EmptyBasketPage from "./emptyBasketPage";
import BasketTable from "./basketTable";

export default function BasketPage() {
  const { company_id } = useParams<{ company_id: string }>();
  const { basket } = useAppSelector(state => state.basket);
  if (!basket) return <h3> <EmptyBasketPage /> </h3>
  return (
    <>
      <Container>
        <BasketTable items={basket.items} />
        <Grid container>
          <Grid item xs={6}></Grid>
          <Grid item xs={6}>
            <BasketSummary />
            <Button component={Link} to={`/${company_id}/checkout`}
              size='large'
              fullWidth
            >
              Checkout
            </Button>
          </Grid>
        </Grid>
      </Container >
    </>
  )
}
