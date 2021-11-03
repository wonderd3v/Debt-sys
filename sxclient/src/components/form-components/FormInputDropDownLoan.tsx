import React, { useEffect, useState } from "react";
import { FormControl, InputLabel, MenuItem, Select } from "@material-ui/core";
import { Controller } from "react-hook-form";
import { FormInputProps } from "./FormInputProps";
import loanServices from "../../services/user.services"


export const FormInputDropdownLoan: React.FC<FormInputProps> = ({
  name,
  control,

}) => {

  const [loans, setLoans] = useState([]);

  const fetchLoans = async () => {
    let response = await loanServices.getAll();
    setLoans(response.data)
  }

  useEffect(() => {
    fetchLoans();
    return () => {

    }
  }, [])

  const generateSingleOptions = () => {
    return loans.map((option: any) => {
      return (
        <MenuItem key={option.id} value={option.id}>
          {option.id}
        </MenuItem>
      );
    });
  };


  return (
    <FormControl size={"medium"} >

      <InputLabel> Id de prestamos </InputLabel>
      <Controller
    
        render={({ field: { onChange, value } }) => (
          <Select onChange={onChange} value={value}>
            {generateSingleOptions()}
          </Select>
        )}
        control={control}
        name={name}
      />
      
    </FormControl>
  );
};

