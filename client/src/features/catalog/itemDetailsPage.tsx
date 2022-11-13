import { Container, Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, Typography } from "@mui/material"
import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import { idText } from "typescript";
import Header from "../../app/layout/Header";
import { Item } from "../../app/models/item";
import { ItemDetails } from "../../app/models/itemDetails";

export default function ItemDetailsPage() {
  const { id } = useParams<{ id: string }>();
  const [item, setItem] = useState<Item | null>(null);
  const [itemDetails, setItemDetails] = useState<ItemDetails[]>([]);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    axios.get(`http://localhost:5000/Get_Item_Details/${id}`)
      .then(response => setItemDetails(response.data))
      .catch(error => console.log(error))
      .finally(() => setLoading(false));
  }, [id]
  )
  useEffect(() => {
    axios.get(`http://localhost:5000/Get_Item_By_Id/${id}`)
      .then(response => setItem(response.data))
      .catch(error => console.log(error))
      .finally(() => setLoading(false));
  }, [id]
  )
  const uniqueSize = [...new Set(itemDetails.map(itemdetail => itemdetail.size + "  "))];
  const uniqueColuor = [...new Set(itemDetails.map(itemdetail => itemdetail.colour))];

  if (loading) return <h3> იტვირთება</h3>
  if (!item) return <h3> პროდუქტი არ მოიძებნა </h3>
  return (
    <><Header /><Container>
      <Typography variant='h2'>
        <Grid container spacing={6}>
          <Grid item xs={6}>
            <img src={item.main_Photo} alt={item.short_Name} style={{ width: '100%' }} />
          </Grid>
          <Grid item xs={6}>
            <Typography variant='h3' align='center'>{item.short_Name} </Typography>
            <TableContainer>
              <Table>
                <TableBody>
                  <TableRow>
                    <TableCell> არესებული ზომები</TableCell>
                    <TableCell >
                      {uniqueSize}</TableCell>
                  </TableRow>
                  <TableRow>
                    <TableCell> არსებული ფერები</TableCell>
                    <TableCell> {uniqueColuor}</TableCell>
                  </TableRow>
                  <TableRow>
                    <TableCell> აღწერა</TableCell>
                    <TableCell> {item.short_Description}</TableCell>
                  </TableRow>
                </TableBody>
              </Table>
            </TableContainer>
            <Typography variant='h4' align='center' color='secondary' >{item.price}₾ </Typography>
          </Grid>
        </Grid>
      </Typography>
    </Container></>
  )
}


