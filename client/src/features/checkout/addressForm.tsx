
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import { useFormContext } from 'react-hook-form';
import AppTextInputs from '../../app/components/appTextInputs';
import AppCheckBox from '../../app/components/appCheckBox';
import { Address } from '../../app/models/adress';
import { useEffect } from 'react';
interface Props {
  address?: Address
}
export default function AddressForm({ address }: Props) {
 
  const { control, formState } = useFormContext();
  return (
    <>
      <Typography variant="h6" gutterBottom>
        მისამართი
      </Typography>

      <Grid container spacing={3}>
        <Grid item xs={12} sm={12}>
          <AppTextInputs control={control} name='fullName' label='სრული სახელი' />
        </Grid>
        <Grid item xs={12}>
          <AppTextInputs control={control} name='adress1' label='მისამართი' />
        </Grid>
        <Grid item xs={12}>
          <AppTextInputs control={control} name='google_Map' label='Google Map Link' />
        </Grid>
        <Grid item xs={12} sm={6}>
          <AppTextInputs control={control} name='city' label='ქალაქი' />
        </Grid>
        <Grid item xs={12} sm={6}>
          <AppTextInputs control={control} name='state' label='რეგიონი' />
        </Grid>
        <Grid item xs={12} sm={6}>
          <AppTextInputs control={control} name='phone_Number' label='ტელეფონის ნომერი' />
        </Grid>
        <Grid item xs={12} sm={6}>
          <AppTextInputs control={control} name='eMail' label='იმეილი' />
        </Grid>
        <Grid item xs={12}>
          <AppCheckBox
            disabled={!formState.isDirty}
            name='saveAdress'
            label='მისამართის შენახვა'
            control={control}
          />
        </Grid>
      </Grid>

    </>
  );
}
