import { Remove, Add, Delete } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import { TableContainer, Paper, Table, TableHead, TableRow, TableCell, TableBody, Box } from "@mui/material";
import { BasketItem } from "../../app/models/basket";
import { useAppSelector, useAppDispatch } from "../../app/store/configureStore";
import { removeBasketItemAsync, addBasketItemAsync } from "./basketSlice";
interface Props {
  items: BasketItem[];
  isBasket?: boolean;
}
export default function BasketTable({ items, isBasket = true }: Props) {
  //const { company_id } = useParams<{ company_id: string }>();
  const { status } = useAppSelector(state => state.basket);
  const dispatch = useAppDispatch();
  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }}>
        <TableHead>
          <TableRow>
            <TableCell>პროდუქტი</TableCell>
            <TableCell align="right">ფასი</TableCell>
            <TableCell align="center">რაოდენობა</TableCell>
            <TableCell align="right">ჯამი</TableCell>
            {isBasket &&
              <TableCell align="right"></TableCell>}
          </TableRow>
        </TableHead>
        <TableBody>
          {items.map(item => (
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
                {isBasket &&
                  <LoadingButton
                    loading={status.includes('pendingDeleteItems' + item.productId)}
                    onClick={() => dispatch(removeBasketItemAsync({ productId: item.productId, quantity: 1 }))}
                    color='error'>
                    <Remove />
                  </LoadingButton>}
                {item.quantity}
                {isBasket &&
                  <LoadingButton
                    loading={status.includes('pendingAddItem' + item.productId)}
                    onClick={() => dispatch(addBasketItemAsync({ productId: item.productId }))}
                    color='secondary'>
                    <Add />
                  </LoadingButton>}
              </TableCell>
              <TableCell align="right">{item.price * item.quantity}₾</TableCell>

              {isBasket && <TableCell align="right">
                <LoadingButton
                  loading={status.includes('pendingDeleteItems' + item.productId)}
                  onClick={() => dispatch(removeBasketItemAsync({ productId: item.productId, quantity: item.quantity }))}
                  color='error'>
                  <Delete />
                </LoadingButton> </TableCell>}
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  )
}


