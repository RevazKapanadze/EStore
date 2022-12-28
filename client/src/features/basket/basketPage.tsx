import { Add, Delete, Remove } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import { Box, Button, Container, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";

import BasketSummary from "./basketSummary";
import { Link, useParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { addBasketItemAsync, removeBasketItemAsync } from "./basketSlice";
import EmptyBasketPage from "./emptyBasketPage";

export default function BasketPage() {
  const { company_id } = useParams<{ company_id: string }>();
  const { basket } = useAppSelector(state => state.basket);
  const { status } = useAppSelector(state => state.basket);
  const dispatch = useAppDispatch();
  if (!basket) return <h3> <EmptyBasketPage /> </h3>

  return (
    <>
      <Container>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }}>
            <TableHead>
              <TableRow>
                <TableCell>პროდუქტი</TableCell>
                <TableCell align="right">ფასი</TableCell>
                <TableCell align="center">რაოდენობა</TableCell>
                <TableCell align="right">ჯამი</TableCell>
                <TableCell align="right"></TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {basket.items.map(item => (
                <TableRow
                  key={item.productId}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    <Box display='flex' alignItems='center'>
                      <img src={item.pictureUrl} alt={item.name} style={{ height: 50, marginRight: 20 }} />
                      <span>{item.name}</span>
                    </Box>

                  </TableCell>
                  <TableCell align="right">{item.price}₾</TableCell>
                  <TableCell align="center">
                    <LoadingButton
                      loading={status.includes('pendingDeleteItems' + item.productId)}
                      onClick={() => dispatch(removeBasketItemAsync({ productId: item.productId, quantity: 1 }))}
                      color='error'>
                      <Remove />
                    </LoadingButton>
                    {item.quantity}
                    <LoadingButton
                      loading={status.includes('pendingAddItem' + item.productId)}
                      onClick={() => dispatch(addBasketItemAsync({ productId: item.productId }))}
                      color='secondary'>
                      <Add />
                    </LoadingButton>
                  </TableCell>
                  <TableCell align="right">{item.price * item.quantity}₾</TableCell>
                  <TableCell align="right">
                    <LoadingButton
                      loading={status.includes('pendingDeleteItems' + item.productId)}
                      onClick={() => dispatch(removeBasketItemAsync({ productId: item.productId, quantity: item.quantity }))}
                      color='error'>
                      <Delete />
                    </LoadingButton> </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
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
