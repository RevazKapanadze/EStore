import { ShoppingCart } from "@mui/icons-material";
import { AppBar, ListItem, Toolbar, Typography, List, Badge, IconButton, Box } from "@mui/material";
import { useEffect, useState } from "react";
import { Link, NavLink, Outlet, useParams } from "react-router-dom";
import agent from "../api/agent";
import { useStoreContext } from "../context/storeContext";
import { Company } from "../models/company";
import LoadingComponent from "./LoadingComponent";


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
  const { basket } = useStoreContext();
  const itemCount = basket?.items.reduce((sum, item) => sum + item.quantity, 0);
  const { company_id } = useParams<{ company_id: string }>();
  const [company, setCompany] = useState<Company | null>(null);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    agent.main.Get_Company_Details(parseInt(company_id!))
      .then(response => setCompany(response))
      .catch(error => console.log(error))
      .finally(() => setLoading(false));
  }, [company_id]
  )
  //const { basket } = useStoreContext();
  // const itemCount = basket?.items.reduce((sum, item) => sum + item.quantity, 0)
  if (loading) return <LoadingComponent message="პროდუქტები იტვირთება" />
  if (!company) return <h3> კომპანია არ მოიძებნა </h3>
  return (
    <><AppBar position='static' sx={{ mb: 4, bgcolor: 'white' }}>
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
            to={`/${company_id}`}
            end
            sx={navStyles}
            style={{ textDecoration: 'none' }}
          >{company.name}
          </Typography>
        </Box>
        <Box display='flex' alignItems='center'>
          <IconButton component={Link} to={`/${company_id}/basket`} size='large' sx={navStyles}>
            <Badge badgeContent={itemCount} color='secondary'>
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
    </AppBar><Outlet /></>

  )
}