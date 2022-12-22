import { Add, Delete, Remove } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import { Box, Button, Container, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { useState } from "react";
import agent from "../../app/api/agent";

import BasketSummary from "./basketSummary";
import { Link, useParams } from "react-router-dom";
import { useAppSelector } from "../../app/store/configureStore";
import { clearBasket, removeBasketItemAsync, setBasket } from "./basketSlice";
import { clear } from "console";

export default function BasketPage() {
  const { company_id } = useParams<{ company_id: string }>();
  const { basket } = useAppSelector(state => state.basket);
  const [status, setStatus] = useState({
    loading: false,
    name: 'name'
  });
  function handleAddItem(productId: number, name: string) {
    setStatus({ loading: true, name });
    agent.basket.addItemTobasket(productId)
      .then(basket => setBasket(basket))
      .catch(error => console.log(error))
      .finally(() => setStatus({ loading: false, name: '' }))
  }
  function handleRemoveItem(productId: number, quantity = 1, name: string) {
    setStatus({ loading: true, name });
    agent.basket.removeItem(productId, quantity)
      .then(() => removeBasketItemAsync({ productId, quantity }))
      .catch(error => console.log(error))
      .finally(() => setStatus({ loading: false, name: '' }))
  }



  if (!basket) return <Typography variant='h3'> you basket is empty</Typography>

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
                      loading={status.loading && status.name === 'rem' + item.productId}
                      onClick={() => handleRemoveItem(item.productId, 1, 'rem' + item.productId)}
                      color='error'>
                      <Remove />
                    </LoadingButton>
                    {item.quantity}
                    <LoadingButton
                      loading={status.loading && status.name === 'add' + item.productId}
                      onClick={() => handleAddItem(item.productId, 'add' + item.productId)}
                      color='secondary'>
                      <Add />
                    </LoadingButton>
                  </TableCell>
                  <TableCell align="right">{item.price * item.quantity}₾</TableCell>
                  <TableCell align="right">
                    <LoadingButton
                      loading={status.loading && status.name === 'del' + item.productId}
                      onClick={() => handleRemoveItem(item.productId, item.quantity, 'del' + item.productId)}
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
