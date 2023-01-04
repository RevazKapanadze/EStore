import * as yup from 'yup';
export const validationSchema = [yup.object({
  fullName: yup.string().required('სრული სახელი აუცილებელია'),
  adress1: yup.string().required('მისამართი აუცილებელია'),
  google_Map: yup.string().notRequired(),
  city: yup.string().required('ქალაქი აუცილებელია'),
  state: yup.string().required('რეგიონი აუცილებელია'),
  phone_Number: yup.string().required('ტელეფონის ნომერი აუცილებელია'),
  eMail: yup.string().required('იმეილი აუცილებელია')
}), yup.object()
  // , yup.object({ nameOnCard: yup.string().required })
  , yup.object()
]

