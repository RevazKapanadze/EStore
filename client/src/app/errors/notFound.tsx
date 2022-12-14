import { Button, Container, Divider, Typography } from "@mui/material";
import { useNavigate, useParams } from "react-router-dom";

export default function NotFound() {
  const Navigate = useNavigate();
  const { company_id } = useParams<{ company_id: string }>();
  return (
    <Container >
      <Typography gutterBottom variant='h3'> oops - we could not find what you are looking for</Typography>
      <Divider />
      <Button onClick={() => Navigate(`/${company_id}/catalog`)}> Go back to the store</Button>
    </Container >
  )
}