import { ShoppingCart } from "@mui/icons-material";
import { AppBar, ListItem, Toolbar, Typography, List, Badge, IconButton, Box, Button } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import { NavLink, useParams } from "react-router-dom";
import { Company } from "../models/company";
const midLinks = [
  { title: 'კომპანიის შესახებ', path: `/${1}/about` }

]
const rightLinks = [
  { title: 'login', path: '/login' },
  { title: 'register', path: '/register' }
]
const navStyles = {
  color: 'black',
  typography: 'h6',
  '&:hover': {
    color: 'grey.500'
  },
  '&:active': {
    color: 'red',
  },
}

export default function Header() {
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
  if (loading) return <h3> იტვირთება</h3>
  if (!company) return <h3> კომპანია არ მოიძებნა </h3>
  return (
    <AppBar position='static' sx={{ mb: 4, bgcolor: 'white' }}>
      <Toolbar sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>

        <Box sx={{ display: 'flex' }}>
          <Typography variant='h6' color="black" align="center" component={NavLink}
            to={`/${company_id}/about`}
            end
            sx={navStyles}
            style={{ textDecoration: 'none' }}
          >
            კომპანიის შესახებ
          </Typography>
        </Box>
        <Box display='flex' alignItems='center'>
          <Typography variant='h6' color="black" align="center" component={NavLink}
            to={`/${company_id}/catalog`}
            end
            sx={navStyles}
            style={{ textDecoration: 'none' }}
          >{company.name}
          </Typography>
        </Box>
        <Box display='flex' alignItems='center'>
          <IconButton size='large' sx={navStyles}>
            <Badge badgeContent={4} color='secondary'>
              <ShoppingCart />
            </Badge>
          </IconButton>
          <List sx={{ display: 'flex' }}>
            {rightLinks.map(({ title, path }) => (
              <ListItem component={NavLink}
                to={path}
                end
                key={path}
                sx={navStyles}>
                {title.toUpperCase()}
              </ListItem>
            ))}
          </List>
        </Box>
      </Toolbar>
    </AppBar >
  )
}