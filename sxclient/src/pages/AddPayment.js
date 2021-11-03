import { useEffect } from "react";
import { Button, Paper, Typography } from "@material-ui/core";
import { useForm } from "react-hook-form";
import { FormInputText } from "../components/form-components/FormInputText";
import { FormInputDropdownLoan } from "../components/form-components/FormInputDropDownLoan";
import paymentServices from "../services/payment.service";



const FormInput = {
    loanId: Number,
    voucher: String,

}

function AddPayment() {

  const methods = useForm({  });
  const { handleSubmit, control } = methods;
  const onSubmit = (data = FormInput) => {
    let newData = {

        loanId: data.loanId,
        voucher: "",
        loanPayments: [
            {
              loanId: data.loanId
            }
        ]
    };

    console.log(newData);
    paymentServices.create(newData);
  }

  useEffect(() => {
    console.log(FormInput);
    return () => {

    }
    }, [])

  return (
    <div className='addPayment'>
       <h1>Pagos</h1>
      <Paper className="addPaper">
        <Typography variant="h6"> Modulo de pagos </Typography>

        <div className="inputBox">
          <FormInputText margin="normal" name="voucher" control={control} label="Especifique detalles y monto" />
        </div>

        <FormInputDropdownLoan name="loanId" control={control} />
       
        <div className="sumbitButton">
          <Button onClick={handleSubmit(onSubmit)} variant={"contained"} color="primary">
            Submit
          </Button>
        </div>
      </Paper>
    </div>
  );
}

export default AddPayment;
