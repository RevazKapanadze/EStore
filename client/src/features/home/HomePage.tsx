import { Container, Typography } from "@mui/material"
import Header from "../../app/layout/Header"

export default function HomePage() {
  return (
    <><Header /><Container>
      <Typography variant='h2'>
        HomePage
      </Typography>
    </Container></>
  )
}