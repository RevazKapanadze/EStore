import { ListItem, ListItemAvatar, Avatar, ListItemText, Button, Card, CardActions, CardContent, CardMedia, Typography, CardHeader } from "@mui/material";
import { Item } from "../../app/models/item";

interface Props {
  item: Item;
}
export default function ItemCard({ item }: Props) {
  return (
    <Card>
      <CardMedia
        sx={{ height: 140, backgroundSize: 'contain', bgcolor: 'primary.light' }}
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
        <Button size="small" > დეტალები</Button>
      </CardActions>
    </Card >
  )
}