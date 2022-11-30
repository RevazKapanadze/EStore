import { TableContainer, Paper, Table, TableBody, TableRow, TableCell, Typography } from "@mui/material";
import { useStoreContext } from "../../app/context/storeContext";

export default function BasketSummary() {
  const { basket } = useStoreContext();
  const subtotal = basket?.items.reduce((sum, item) => sum + (item.quantity * item.price), 0) ?? 0;
  const deliveryFee = subtotal > 100 ? 0 : 5;
  const commission = subtotal * 12 / 1000;

  return (
    <>
      <TableContainer component={Paper} variant={'outlined'}>
        <Table>
          <TableBody>
            <TableRow>
              <TableCell colSpan={2}>ჯამი</TableCell>
              <TableCell align="right">{subtotal}₾</TableCell>
            </TableRow>
            <TableRow>
              <TableCell colSpan={2}>მიტანის ხარჯი</TableCell>
              <TableCell align="right">{deliveryFee}₾</TableCell>
            </TableRow>
            <TableRow>
              <TableCell colSpan={2}>საკომისიო</TableCell>
              <TableCell align="right">{(commission).toFixed(2)}₾</TableCell>
            </TableRow>
            <TableRow>
              <TableCell colSpan={2}>ჯამში</TableCell>
              <TableCell align="right">{(subtotal + deliveryFee + commission).toFixed(2)}₾</TableCell>
            </TableRow>
            <TableRow>
              <TableCell>
                <span style={{ fontStyle: 'italic' }}>თუ შეკვეთა მეტია 100₾ ზე მიტანა უფასოა !!!</span>
              </TableCell>
            </TableRow>
          </TableBody>
        </Table>
      </TableContainer>
    </>
  )
}