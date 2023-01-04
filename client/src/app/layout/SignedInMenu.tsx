import { Button, Menu, Fade, MenuItem, colors, Typography } from "@mui/material";
import React from "react";
import { Link, useParams } from "react-router-dom";
import { signOut } from "../../features/account/accountSlice";
import { clearBasket } from "../../features/basket/basketSlice";
import { useAppDispatch, useAppSelector } from "../store/configureStore";

export default function SignedInMenu() {
  const { company_id } = useParams<{ company_id: string }>();
  const dispatch = useAppDispatch();
  const { user } = useAppSelector(state => state.account);
  const [anchorEl, setAnchorEl] = React.useState(null);
  const open = Boolean(anchorEl);
  const handleClick = (event: any) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <>
      <Button
        color='inherit'
        onClick={handleClick}
        sx={{ typography: 'h6' }}
      >
        <Typography variant='h6' color="black" align="center"> {user?.email}</Typography>
      </Button>
      <Menu
        anchorEl={anchorEl}
        open={open}
        onClose={handleClose}
        TransitionComponent={Fade}
      >
        <MenuItem onClick={handleClose}>პროფილი</MenuItem>
        <MenuItem component={Link} to={`/${company_id}/orders`}> ჩემი შეკვეთები</MenuItem>
        <MenuItem onClick={() => {
          dispatch(signOut());
          dispatch(clearBasket());
        }}>გამოსვლა</MenuItem>
      </Menu>
    </>
  );
}