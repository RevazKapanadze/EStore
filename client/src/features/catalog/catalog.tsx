import { List, ListItemAvatar, ListItem, Avatar, ListItemText } from "@mui/material";
import { useState, useEffect } from "react";
import { Item } from "../../app/models/item";
import ItemList from "./itemList";

export default function Catalog() {
  const [items, setProducts] = useState<Item[]>([]);
  useEffect(() => {
    fetch('http://localhost:5000/Get_All_Items')
      .then(response => response.json())
      .then(data => setProducts(data))
  }, [])

  return (
    <>
      <ItemList items={items} />

    </>
  )
}