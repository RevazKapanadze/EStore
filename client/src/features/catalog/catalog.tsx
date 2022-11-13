import { List, ListItemAvatar, ListItem, Avatar, ListItemText, Container } from "@mui/material";
import axios from "axios";
import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import Header from "../../app/layout/Header";
import { Item } from "../../app/models/item";
import ItemList from "./itemList";

export default function Catalog() {
  const { company_id } = useParams<{ company_id: string }>();
  const [items, setProducts] = useState<Item[]>([]);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    axios.get(`http://localhost:5000/Get_All_Items/${company_id}/_?orderSize=0`)
      .then(response => setProducts(response.data))
      .catch(error => console.log(error))
      .finally(() => setLoading(false))
  }, [company_id])
  if (loading) return <h3> იტვირთება</h3>
  if (!items) return <h3> პროდუქტი არ მოიძებნა</h3>
  return (
    <>
      <Header />
      <Container>
        <ItemList items={items} />
      </Container>
    </>
  )
}