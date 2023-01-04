import { Link, useParams } from "react-router-dom";

import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import agent from '../../app/api/agent';
import { useState, useEffect } from 'react';
import LoadingComponent from '../../app/layout/LoadingComponent';
import { Order } from '../../app/models/order';
import { Button } from '@mui/material';
import { Container } from '@mui/system';
import OrderDetails from "./orderDetails";




export default function Orders() {

  const [orders, setOrders] = useState<Order[] | null>(null);
  const [loading, setLoading] = useState(true);
  const [selectedOrderNumber, setSelectedOrderNumber] = useState(0);
  useEffect(() => {
    agent.orders.list()
      .then(orders => setOrders(orders))
      .catch(error => console.log(error))
      .finally(() => setLoading(false))
  }, [])
  if (selectedOrderNumber > 0) return (
    <OrderDetails
      order={orders?.find(o => o.id === selectedOrderNumber)!}
      setSelectedOrder={setSelectedOrderNumber}
    />)

  if (loading) return <LoadingComponent message='შეკვეთები იტვირთება' />
  return (
    <Container>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>შეკვეთის ნომერი </TableCell>
              <TableCell align="right">ჯამი</TableCell>
              <TableCell align="right">შეკვეთის თარიღი</TableCell>
              <TableCell align="right">სტატუსი</TableCell>
              <TableCell align="right">დეტალები</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {orders?.map((order) => (
              <TableRow
                key={order.id}
                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {order.id}
                </TableCell>
                <TableCell align="right">{order.total}₾</TableCell>
                <TableCell align="right">{order.orderDate.slice(0, 10)}</TableCell>
                <TableCell align="right">{order.orderStatus}</TableCell>
                <TableCell align="right"> <Button onClick={() => setSelectedOrderNumber(order.id)}> ნახვა</Button></TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Container>
  );
}