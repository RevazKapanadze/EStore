import { List, ListItem, ListItemAvatar, Avatar, ListItemText, Grid } from "@mui/material";
import { Item } from "../../app/models/item";
import ItemCard from "./itemCard";

interface Props {
  items: Item[];
}
export default function ItemList({ items }: Props) {
  return (
    <Grid container spacing={4}>
      {items.map(item => (
        <Grid item xs={3}>
          <ItemCard key={item.id} item={item} />
        </Grid>
      ))
      }
    </Grid >
  )
}