import { ListItem, ListItemAvatar, Avatar, ListItemText, Button, Card, CardActions, CardContent, CardMedia, Typography, CardHeader } from "@mui/material";
import { Link, useParams } from "react-router-dom";
import agent from "../../app/api/agent";
import { Item } from "../../app/models/item";
import { useState, useEffect } from "react";
import { LoadingButton } from "@mui/lab";
import { SettingsBackupRestoreTwoTone } from "@mui/icons-material";
import { useStoreContext } from "../../app/context/storeContext";

interface Props {
  item: Item;
}
export default function ItemCard({ item }: Props) {
  const { company_id } = useParams<{ company_id: string }>();
  const { setBasket } = useStoreContext();

  const [loading, setLoading] = useState(false);
  function handleAddItem(productId: number) {
    setLoading(true);
    agent.basket.addItemTobasket(productId)
      .then(basket => setBasket(basket))
      .catch(error => console.log(error))
      .finally(() => setLoading(false))
  }
  return (
    <Card>
      <CardMedia
        sx={{ height: 140, backgroundSize: 'contain', bgcolor: 'white' }}
        image={item.main_Photo}
        title={item.short_Description}
      />
      <CardContent>
        <Typography gutterBottom variant="h4" color="text.secondary" align="center">
          {item.short_Name}
        </Typography>
        <Typography color="secondary" variant="h4" align="center">
          {(item.price).toFixed(2)}  ₾
        </Typography>
      </CardContent>
      <CardActions>
        <LoadingButton
          loading={loading}
          onClick={() => handleAddItem(item.id)}
          size="small">კალათში დამატება</LoadingButton>
        <Button component={Link} to={`/${company_id}/${item.id}`} size="small" > დეტალები</Button>
      </CardActions>
    </Card >
  )
}