import { useEffect } from "react";
import { Button, Paper, Typography } from "@material-ui/core";
import { useForm } from "react-hook-form";
import { FormInputText } from "../components/form-components/FormInputText";
import { FormInputDropdown } from "../components/form-components/FormInputDropdown";
import { FormInputRadio } from "../components/form-components/FormInputRadio";
import { FormInputDropdownUser } from "../components/form-components/FormInputDropdownUser";
import loansServices from "../services/loans.services";


const FormInput = {
  amount: Number,
  amountOfPayments: Number,
  term: Number,
  status: 3,
  creditorId: Number,
  debtorId: 5
}

function AddLoan() {

  const methods = useForm({  });
  const { handleSubmit, control } = methods;
  const onSubmit = (data = FormInput) => {
    let newData = {
      amount: parseInt(data.amount),
      amountOfPayments: parseInt(data.amountOfPayments),
      term: parseInt(data.term),
      status: 3,
      creditorId: data.creditorId,
      debtorId: 5
    };

    console.log(newData);
    loansServices.create(newData);
  }

  useEffect(() => {
    console.log(FormInput);
    return () => {

    }
    }, [])

  return (
    <div className='add'>
      <Paper className="addPaper">
        <Typography variant="h6"> Modulo de prestamo </Typography>

        <div className="inputBox">
          <FormInputText margin="normal" name="amount" control={control} label="Digite eI monto que quiere expedir o solicitar" />
        </div>

        <FormInputDropdown name="amountOfPayments" control={control} label=" Cantidad de pagos" />

        <div className="radioButtonBox">
          <FormInputRadio className="radioButtons" name="term" control={control} label={"Termino o frecuencia de pago"} />
        </div>


        <FormInputDropdownUser name="creditorId" control={control} />

        <div className="sumbitButton">
          <Button onClick={handleSubmit(onSubmit)} variant={"contained"} color="primary">
            Submit
          </Button>
        </div>
      </Paper>
    </div>
  );
}

export default AddLoan;





