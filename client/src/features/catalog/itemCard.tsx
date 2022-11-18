import { ListItem, ListItemAvatar, Avatar, ListItemText, Button, Card, CardActions, CardContent, CardMedia, Typography, CardHeader } from "@mui/material";
import { Link, useParams } from "react-router-dom";
import { Item } from "../../app/models/item";

interface Props {
  item: Item;
}
export default function ItemCard({ item }: Props) {
  const { company_id } = useParams<{ company_id: string }>();
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
        <Button component={Link} to={`/${company_id}/${item.id}`} size="small" > დეტალები</Button>
      </CardActions>
    </Card >
  )
}