import { Container, Grid } from "@mui/material";
import { Company } from "../../app/models/company";
import ItemCard from "../catalog/itemCard";
import CompaniesCard from "./CompaniesCard";

interface Props {
  companies: Company[];
}

export default function CompaniesList({ companies }: Props) {
  return (
    <Grid container spacing={6}>
      {companies.map(company => (
        <Grid item xs={2}>
          <CompaniesCard key={company.id} company={company} />
        </Grid>
      ))
      }
    </Grid >
  )
}