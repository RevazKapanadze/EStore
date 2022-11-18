import { Card, CardMedia, CardContent, Typography, CardActions, Button } from "@mui/material";
import { Company } from "../../app/models/company";
import { Link } from "react-router-dom";


interface Props {
  company: Company;
}

export default function CompaniesCard({ company }: Props) {
  return (
    <Card component={Link} to={`/${company.id}`} style={{ textDecoration: 'none' }}>
      <CardMedia
        sx={{ height: 140, backgroundSize: 'contain', bgcolor: 'primary.light' }}
        image={company.company_Logo}
      />
      <CardContent sx={{ backgroundSize: 'contain', height: 70 }}>
        <Typography color="text.secondary" textAlign="center" >
          {company.name}
        </Typography>
      </CardContent>
    </Card >
  )
}