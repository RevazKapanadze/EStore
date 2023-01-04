import { Remove, Add, Delete } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import { Button, Container, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { BasketItem } from "../../app/models/basket";
import { Order } from "../../app/models/order";
import { removeBasketItemAsync, addBasketItemAsync } from "../basket/basketSlice";
import BasketSummary from "../basket/basketSummary";
import BasketTable from "../basket/basketTable";


interface Props {
  order: Order;
  setSelectedOrder: (id: number) => void;
}

export default function OrderDetailed({ order, setSelectedOrder }: Props) {
  const subtotal = order.orderItems.reduce((sum, item) => sum + (item.quantity * item.price), 0) ?? 0;
  return (
    <Container>
      <Box display='flex' justifyContent='space-between'>
        <Typography sx={{ p: 2 }} gutterBottom variant='h4'>Order# {order.id} </Typography>
        <Typography sx={{ p: 2 }} gutterBottom variant='h4'>სტატუსი - {order.orderStatus}</Typography>
        <Button onClick={() => setSelectedOrder(0)} sx={{ m: 2 }} size='large' variant='contained'>შეკვეთების გვერდზე დაბრუნება</Button>
      </Box>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }}>
          <TableHead>
            <TableRow>
              <TableCell>პროდუქტი</TableCell>
              <TableCell align="right">ფასი</TableCell>
              <TableCell align="right">რაოდენობა</TableCell>
              <TableCell align="right">ჯამი</TableCell>
              <TableCell align="right"></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {order.orderItems.map(item => (
              <TableRow
                key={item.itemId}
                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  <Box display='flex' alignItems='center'>
                    <img src={item.pictureUrl} alt={item.name} style={{ height: 50, marginRight: 20 }} />
                    <span>{item.name}</span>
                  </Box>
                </TableCell>
                <TableCell align="right">{item.price}₾</TableCell>
                <TableCell align="right">{item.quantity}</TableCell>
                <TableCell align="right">{item.price * item.quantity}₾</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <Grid container>
        <Grid item xs={6} />
        <Grid item xs={6}>
          <BasketSummary subtotal={subtotal} />
        </Grid>
      </Grid>
    </Container>
  )
}