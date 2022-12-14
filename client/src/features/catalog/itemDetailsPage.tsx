import { LoadingButton } from "@mui/lab";
import { Box, Container, Divider, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableRow, TextField, Typography } from "@mui/material"
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import agent from "../../app/api/agent";

import NotFound from "../../app/errors/notFound";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { Item } from "../../app/models/item";
import { ItemDetails } from "../../app/models/itemDetails";
import { useAppSelector } from "../../app/store/configureStore";
import { clearBasket, removeBasketItemAsync, setBasket } from "../basket/basketSlice";

export default function ItemDetailsPage() {
  const { basket } = useAppSelector(state => state.basket);
  const { company_id } = useParams<{ company_id: string }>();
  const { id } = useParams<{ id: string }>();
  const [item, setItem] = useState<Item | null>(null);
  const [itemDetails, setItemDetails] = useState<ItemDetails[]>([]);
  const [loading, setLoading] = useState(true);
  const [quantity, setQuantity] = useState(0);
  const [submitting, setSubmitting] = useState(false);
  const item2 = basket?.items.find(i => i.productId === item?.id);
  useEffect(() => {

    agent.main.Get_Item_Details(parseInt(id!))
      .then(response => setItemDetails(response))
      .catch(error => console.log(error))
      .finally(() => setLoading(false));
  }, [id]
  )
  useEffect(() => {
    if (item2) setQuantity(item2.quantity);
    agent.main.Get_Item_By_Id(parseInt(id!), parseInt(company_id!))
      .then(response => setItem(response))
      .catch(error => console.log(error))
      .finally(() => setLoading(false));
  }, [id, item2]
  )
  function handleInputChange(event: any) {
    if (event.target.value >= 0) {
      setQuantity(parseInt(event.target.value));
    }
  }
  function handleUpdateCart() {
    setSubmitting(true);
    if (!item2 || quantity > item2.quantity) {
      const updatedQuantity = item2 ? quantity - item2?.quantity : quantity;
      agent.basket.addItemTobasket(item?.id!, updatedQuantity)
        .then(basket => setBasket(basket))
        .catch(error => console.log(error))
        .finally(() => setSubmitting(false))
    } else {
      const updatedQuantity = item2.quantity - quantity;
      agent.basket.removeItem(item?.id!, updatedQuantity)
        .then(() => removeBasketItemAsync({ productId: item?.id!, quantity: updatedQuantity, name: 'rem' }))
        .catch(error => console.log(error))
        .finally(() => setSubmitting(false))
    }
  }
  const uniqueSize = [...new Set(itemDetails.map(itemdetail => itemdetail.size + "  "))];
  const uniqueColuor = [...new Set(itemDetails.map(itemdetail => itemdetail.colour))];

  if (loading) return <LoadingComponent message="???????????????????????? ???????????????????????????" />
  if (!item) return <h3> <NotFound /> </h3>
  return (
    <Container>
      <Typography variant='h2'>
        <Grid container spacing={10} sx={{ width: '100%' }}>
          <Grid item xs={6} >
            <img src={item.main_Photo} alt={item.short_Name} style={{ width: '100%' }} />
          </Grid>
          <Grid item xs={6} >
            <Typography variant='h3' align='center' paddingBottom={10}>{item.short_Name} </Typography>
            <Container>
              <TableContainer>
                <Table>
                  <TableBody>
                    <TableRow>
                      <TableCell> ??????????????????????????? ??????????????????</TableCell>
                      <TableCell >
                        {uniqueSize}</TableCell>
                    </TableRow>
                    <TableRow>
                      <TableCell> ???????????????????????? ??????????????????</TableCell>
                      <TableCell> {uniqueColuor}</TableCell>
                    </TableRow>
                    <TableRow>
                      <TableCell> ??????????????????</TableCell>
                      <TableCell> {item.short_Description}</TableCell>
                    </TableRow>
                  </TableBody>
                </Table>
              </TableContainer>
            </Container>
            <Grid item xs={6} />
            <Container sx={{margin: 3}}>
              <Table >
                <Grid container spacing={2}>
                  <Grid item xs={6} sx={{}} >
                    <TextField
                      onChange={handleInputChange}
                      variant='outlined'
                      type='number'
                      label='??????????????????????????? ?????????????????????'
                      fullWidth
                      value={quantity}
                    />
                  </Grid>
                  <Grid item xs={6}>
                    <LoadingButton
                      disabled={item2?.quantity === quantity || !item2 && quantity === 0}
                      loading={submitting}
                      onClick={handleUpdateCart}
                      sx={{ height: 0.8, alignContent:'center' }}
                      color='primary'
                      size='large'
                      variant='contained'
                      fullWidth
                    >
                      {item2 ? '?????????????????????????????? ??????????????????' : '????????????????????? ????????????????????????'}
                    </LoadingButton>
                  </Grid>
                </Grid>
              </Table>
            </Container>
            <Typography variant='h4' align='center' color='secondary' >{item.price}??? </Typography>
          </Grid>
        </Grid>
      </Typography>
    </Container>
  )
}


