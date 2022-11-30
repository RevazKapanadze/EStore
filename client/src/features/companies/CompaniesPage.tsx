import { Container, Typography } from "@mui/material"
import { useState, useEffect } from "react";
import { Company } from "../../app/models/company";
import { List, ListItemAvatar, ListItem, Avatar, ListItemText } from "@mui/material";
import axios from "axios";
import { Item } from "../../app/models/item";
import CompaniesList from "./CompaniesList";
import agent from "../../app/api/agent";


export default function CompaniesPage() {
  const [company, setCompany] = useState<Company[]>([])
  useEffect(() => {
    agent.main.Get_All_Companies()
      .then(response => setCompany(response))
      .catch(error => console.log(error))
  }, [])
  

  return (
    <Container sx={{ paddingTop: 6 }}>
      <CompaniesList companies={company} />
    </Container>
  )
}