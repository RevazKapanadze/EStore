import { Button, ButtonGroup, Container, Typography } from "@mui/material"
import agent from "../../app/api/agent"
import Header from "../../app/layout/Header"

export default function HomePage() {
  return (
    <Container>
      <Typography gutterBottom variant='h2'> test eerors</Typography >
      <ButtonGroup fullWidth>
        <Button variant='contained' onClick={() => agent.TestErrors.get400error().catch(error => console.log(error))}> test 400 </Button>
        <Button variant='contained' onClick={() => agent.TestErrors.get401error().catch(error => console.log(error))}> test 401 </Button>
        <Button variant='contained' onClick={() => agent.TestErrors.get404error().catch(error => console.log(error))}> test 404 </Button>
        <Button variant='contained' onClick={() => agent.TestErrors.get500error().catch(error => console.log(error))}> test 500 </Button>
        <Button variant='contained' onClick={() => agent.TestErrors.getValidatioError().catch(error => console.log(error))}> test val </Button>
      </ButtonGroup>
    </Container>
  )
}