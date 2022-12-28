import { Button, Container, Divider, Typography } from "@mui/material";
import { useNavigate, useParams } from "react-router-dom";

export default function EmptyBasketPage() {
  const Navigate = useNavigate();
  const { company_id } = useParams<{ company_id: string }>();
  return (
    <Container >
      <Typography gutterBottom variant='h3'> სამწუხაროთ შენ არ გავქს პროდუქტი კალათში</Typography>
      <Divider />
      <Button onClick={() => Navigate(`/${company_id}/catalog`)}> დაბრუნდი პროდუქტებში</Button>
    </Container >
  )
}