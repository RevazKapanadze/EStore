import { Alert, AlertTitle, Button, ButtonGroup, Container, List, ListItem, ListItemText, Typography } from "@mui/material"
import { error } from "console";
import { useState } from "react";
import agent from "../../app/api/agent"
import Header from "../../app/layout/Header"

export default function HomePage() {
  const [validationErrors, setValidationErrors] = useState<string[]>([]);
  function getValidatioError() {
    agent.TestErrors.getValidatioError()
      .then(() => console.log('should not see this'))
      .catch(error => setValidationErrors(error));
  }
  return (
    <Container>
      <Typography gutterBottom variant='h2'> test eerors</Typography >
      <ButtonGroup fullWidth>
        <Button variant='contained' onClick={() => agent.TestErrors.get400error().catch(error => console.log(error))}> test 400 </Button>
        <Button variant='contained' onClick={() => agent.TestErrors.get401error().catch(error => console.log(error))}> test 401 </Button>
        <Button variant='contained' onClick={() => agent.TestErrors.get404error().catch(error => console.log(error))}> test 404 </Button>
        <Button variant='contained' onClick={() => agent.TestErrors.get500error().catch(error => console.log(error))}> test 500 </Button>
        <Button variant='contained' onClick={getValidatioError}> test val </Button>
      </ButtonGroup>
      {validationErrors.length > 0 &&
        <Alert severity="error">
          <AlertTitle>validation eRrors
            <List>
              {validationErrors.map(error => (
                <ListItem key={error}>
                  <ListItemText>{error}</ListItemText>
                </ListItem>))}
            </List>
          </AlertTitle>
        </Alert>}
    </Container>
  )
}