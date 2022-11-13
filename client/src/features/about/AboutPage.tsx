import { Container, Divider, Typography } from "@mui/material"
import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Header from "../../app/layout/Header"

import { Company } from "../../app/models/company";

export default function AboutPage() {
  const { company_id } = useParams<{ company_id: string }>();
  const [company, setCompany] = useState<Company | null>(null);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    axios.get(`http://localhost:5000/Get_Company_Details/${company_id}`)
      .then(response => setCompany(response.data))
      .catch(error => console.log(error))
      .finally(() => setLoading(false));
  }, [company_id]
  )
  return (
    <><Header /><Container>
      <Typography variant='h2' align='center'>
        <img src={company?.company_Logo} />
      </Typography>
      <Divider />
      <Divider />
      <Typography variant='h5' align='center'>
        {company?.details}
      </Typography>
    </Container></>
  )
}