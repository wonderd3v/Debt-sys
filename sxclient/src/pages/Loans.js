import { useState, useEffect } from "react";
import loanServices from "../services/loans.services";
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';
import Paper from '@mui/material/Paper';
import { validateTerm, validateLoanStatus } from "../utils/helpers";
import AddPayment from "./AddPayment";

const Loans = () => {

  const [loans, setLoans] = useState([]);

  const getLoans = async () => {
    let response = await loanServices.getAll();
    setLoans(response.data);
  }

  useEffect(() => {
    getLoans();

  }, [])

  return <>
    <div className="loanParentContainer">
      <h1>Prestamos </h1>
      <TableContainer className="tableContainer" component={Paper}>
        <Table sx={{ minWidth: 500 }} aria-label="simple table">
          <TableHead>
            <TableRow>

              <TableCell>Monto del prestamo</TableCell>
              <TableCell>Fecha de creacion</TableCell>
              <TableCell>Frecuancia de pagos</TableCell>
              <TableCell>Cantidad de pagos</TableCell>
              <TableCell>Estado del prestamo</TableCell>
              <TableCell>Usuario deudor</TableCell>
              <TableCell>Usuario acreedor</TableCell>
              <TableCell>Pagos efectuados</TableCell>
              <TableCell>Siguiente fecha de pago</TableCell>

            </TableRow>

          </TableHead>
          <TableBody>
            {loans.map((row) => (
              <TableRow
                key={row.Id}
                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
              >
                <TableCell align="left">{row.amount}</TableCell>
                <TableCell >{row.creationDate.split("T")}</TableCell>
                <TableCell >{validateTerm(row.term)}</TableCell>
                <TableCell >{row.amountOfPayments}</TableCell>
                <TableCell >{validateLoanStatus(row.status)}</TableCell>
                <TableCell >{row.debtorId} </TableCell>
                <TableCell >{row.creditorId} </TableCell>

                <TableCell >{row.paymentsMade} </TableCell>
                <TableCell >{row.nextPaymentDate} </TableCell>

              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </div>
    
    <AddPayment />
  </>
}


export default Loans;