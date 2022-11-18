import { Container, Grid, Table, TableBody, TableCell, TableContainer, TableRow, Typography } from "@mui/material"
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import agent from "../../app/api/agent";
import NotFound from "../../app/errors/notFound";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { Item } from "../../app/models/item";
import { ItemDetails } from "../../app/models/itemDetails";

export default function ItemDetailsPage() {

  const { id } = useParams<{ id: string }>();
  const [item, setItem] = useState<Item | null>(null);
  const [itemDetails, setItemDetails] = useState<ItemDetails[]>([]);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    agent.main.Get_Item_Details(parseInt(id!))
      .then(response => setItemDetails(response))
      .catch(error => console.log(error))
      .finally(() => setLoading(false));
  }, [id]
  )
  useEffect(() => {
    agent.main.Get_Item_By_Id(parseInt(id!))
      .then(response => setItem(response))
      .catch(error => console.log(error))
      .finally(() => setLoading(false));
  }, [id]
  )
  const uniqueSize = [...new Set(itemDetails.map(itemdetail => itemdetail.size + "  "))];
  const uniqueColuor = [...new Set(itemDetails.map(itemdetail => itemdetail.colour))];

  if (loading) return <LoadingComponent message="პროდუქტი იტვირთება" />
  if (!item) return <h3> <NotFound /> </h3>
  return (
    <><Container>
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


