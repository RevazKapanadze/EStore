
import { Box, Button, Container, Paper, Step, StepLabel, Stepper, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { FieldValues, FormProvider, useForm } from "react-hook-form";
import AddressForm from "./addressForm";
import Review from "./review";
import { yupResolver } from "@hookform/resolvers/yup"
import { validationSchema } from "./checkoutValidation";
import { useParams } from "react-router-dom";
import agent from "../../app/api/agent";
import { useAppDispatch } from "../../app/store/configureStore";
import { clearBasket } from "../basket/basketSlice";
import { useNavigate } from "react-router-dom";
const steps = ['მისამართი', 'შეკვეთის დეტალები'];

function getStepContent(step: number) {
  switch (step) {
    case 0:
      return <AddressForm />;
    case 1:
      return <Review />;

    default:
      throw new Error('ამოუცნობი ნაბიჯი');
  }
}

export default function CheckoutPage() {
  const dispatch = useAppDispatch();
  const { company_id } = useParams<{ company_id: string }>();
  const [activeStep, setActiveStep] = useState(0);
  const [orderNumber, setOrderNumber] = useState(0);
  const [loading, setLoading] = useState(false);
  const currentValidationSchema = validationSchema[activeStep];
  const methods = useForm({
    mode: 'all',
    resolver: yupResolver(currentValidationSchema)
  });
  useEffect(() => {
    agent.orders.fetchAdress().
      then(response => {
        if (response) {
          methods.reset({ ...methods.getValues(), ...response, saveAdress: false })
        }
      })
  }, [methods])

  const handleNext = async (data: FieldValues) => {
    const { saveAdress, ...shippingAdress } = data;
    if (activeStep === steps.length - 1) {
      setLoading(true);
      try {
        const orderNumber = await agent.orders.create({ saveAdress, company_id, shippingAdress });
        setOrderNumber(orderNumber);
        setActiveStep(activeStep + 1);
        dispatch(clearBasket())
        setLoading(false);
      } catch (error) {
        console.log(error);
        setLoading(false);
      }
    } else { setActiveStep(activeStep + 1); console.log("shit") }

  };

  const handleBack = () => {
    setActiveStep(activeStep - 1);
  };

  return (
    <FormProvider{...methods}>
      <Container>
        <Paper variant="outlined" sx={{ my: { xs: 3, md: 6 }, p: { xs: 2, md: 3 } }}>
          <Typography component="h1" variant="h4" align="center">
            Checkout
          </Typography>
          <Stepper activeStep={activeStep} sx={{ pt: 3, pb: 5 }}>
            {steps.map((label) => (
              <Step key={label}>
                <StepLabel>{label}</StepLabel>
              </Step>
            ))}
          </Stepper>
          <>
            {activeStep === steps.length ? (
              <>
                აქ აიფეის გვერდი ჩაემატება შემდეგ
              </>
            ) : (
              <form onSubmit={methods.handleSubmit(handleNext)}>
                {getStepContent(activeStep)}
                <Box sx={{ display: 'flex', justifyContent: 'flex-end' }}>
                  {activeStep !== 0 && (
                    <Button onClick={handleBack} sx={{ mt: 3, ml: 1 }}>
                      უკან
                    </Button>
                  )}
                  <Button
                    disabled={!methods.formState.isValid}
                    variant="contained"
                    type='submit'
                    sx={{ mt: 3, ml: 1 }}
                  >
                    {activeStep === steps.length - 1 ? 'გადახდის გვერდზე გადასავლა' : 'შემდეგ'}
                  </Button>
                </Box>
              </form>
            )}
          </>
        </Paper>
      </Container>
    </FormProvider>
  );
}



