import { Grid } from "@mui/material";
import { Item } from "../../app/models/item";
import { useAppSelector } from "../../app/store/configureStore";
import ItemCard from "./itemCard";
import ItemCardSkeleton from "./itemCardSkeleton";

interface Props {
  items: Item[];
}
export default function ItemList({ items }: Props) {
  const { productsLoaded } = useAppSelector(state => state.catalog);
  return (
    <Grid container spacing={4}>
      {items.map(item => (
        <Grid item xs={3} key={item.id}>

          {!productsLoaded ? (<ItemCardSkeleton />) : (<ItemCard key={item.id} item={item} />)}
        </Grid>
      ))
      }
    </Grid >
  )
}