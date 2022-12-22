import TextField from '@mui/material/TextField';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { Avatar, Paper } from '@mui/material';
import { Link, useLocation, useNavigate, useParams } from 'react-router-dom';
import { FieldValues, useForm } from 'react-hook-form';
import { LoadingButton } from '@mui/lab';
import { signInUser } from './accountSlice';
import { useAppDispatch } from '../../app/store/configureStore';
import { useMemo } from 'react';


export default function Login() {
  const { company_id } = useParams<{ company_id: string }>();
  const history = useNavigate();
  const location = useLocation();
  const dispatch = useAppDispatch();
  const { register, handleSubmit, formState: { isSubmitting, errors, isValid } } = useForm({
    mode: 'all'
  });
  const from = useMemo(() => {
    const state = location.state as { from: Location };
    if (state && state.from && state.from.pathname) {
      return state.from?.pathname;
    }

    return null;
  }, [location]);
  async function submitForm(data: FieldValues) {
    try {
      await dispatch(signInUser(data));
      history(from || `/${company_id}`);
    } catch (error) {
      console.log(error);
    }
  }


  return (
    <Container component={Paper} maxWidth="sm" sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', p: 4 }}>
      <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
        <LockOutlinedIcon />
      </Avatar>
      <Typography component="h1" variant="h5">
        Sign in
      </Typography>
      <Box component="form" onSubmit={handleSubmit(submitForm)} noValidate sx={{ mt: 1 }}>
        <TextField
          margin="normal"
          fullWidth
          label="მომხმარებელი"
          autoFocus
          {...register('username', { required: 'მომხმარებელი აუცილებელია' })}
          error={!!errors.username}
        /*helperText={errors?.username?.message}*/
        />
        <TextField
          margin="normal"
          fullWidth
          label="პაროლი"
          type="password"
          {...register('password', { required: 'პაროლი აუცილებელია' })}
          error={!!errors.password}
        /* helperText={errors?.password?.message}*/
        />
        <LoadingButton
          disabled={!isValid}
          loading={isSubmitting}
          type="submit"
          fullWidth
          variant="contained"
          sx={{ mt: 3, mb: 2 }}
        >
          შესვლა
        </LoadingButton>
        <Grid container>
          <Grid item>
            <Link to='/register'>
              {"თუ არ ხართ დარეგისტრირებული, დარეგისტრირდით"}
            </Link>
          </Grid>
        </Grid>
      </Box>
    </Container>
  );
}


