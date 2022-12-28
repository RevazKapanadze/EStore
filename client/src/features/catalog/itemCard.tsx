import { ListItem, ListItemAvatar, Avatar, ListItemText, Button, Card, CardActions, CardContent, CardMedia, Typography, CardHeader } from "@mui/material";
import { Link, useParams } from "react-router-dom";
import agent from "../../app/api/agent";
import { Item } from "../../app/models/item";
import { useState, useEffect } from "react";
import { LoadingButton } from "@mui/lab";
import { SettingsBackupRestoreTwoTone } from "@mui/icons-material";

import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { addBasketItemAsync, setBasket } from "../basket/basketSlice";

interface Props {
  item: Item;
}
export default function ItemCard({ item }: Props) {
  const { company_id } = useParams<{ company_id: string }>();
  const { status } = useAppSelector(state => state.basket);
  const dispatch = useAppDispatch();



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
          loading={status.includes('pendingAddItem' + item.id)}
          onClick={() => dispatch(addBasketItemAsync({ productId: item.id }))}
          size="small">კალათში დამატება</LoadingButton>
        <Button component={Link} to={`/${company_id}/${item.id}`} size="small" > დეტალები</Button>
      </CardActions>
    </Card >
  )
}