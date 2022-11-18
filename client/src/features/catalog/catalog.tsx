import { List, ListItemAvatar, ListItem, Avatar, ListItemText, Container } from "@mui/material";
import axios from "axios";
import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import agent from "../../app/api/agent";
import Header from "../../app/layout/Header";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { Item } from "../../app/models/item";
import ItemList from "./itemList";

export default function Catalog() {
  const { company_id } = useParams<{ company_id: string }>();
  const [items, setProducts] = useState<Item[]>([]);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    agent.main.Get_All_Items(parseInt(company_id!))
      .then(response => setProducts(response))
      .catch(error => console.log(error))
      .finally(() => setLoading(false))
  }, [company_id])
  if (loading) return <LoadingComponent message="პროდუქტები იტვირთება" />
  if (!items) return <h3> პროდუქტი არ მოიძებნა</h3>
  return (
    <>
      <Container>
        <ItemList items={items} />
      </Container>
    </>
  )
}