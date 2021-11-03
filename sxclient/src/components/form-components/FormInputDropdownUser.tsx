import React, { useEffect, useState } from "react";
import { FormControl, InputLabel, MenuItem, Select } from "@material-ui/core";
import { Controller } from "react-hook-form";
import { FormInputProps } from "./FormInputProps";
import userServices from "../../services/user.services"


export const FormInputDropdownUser: React.FC<FormInputProps> = ({
  name,
  control,

}) => {

  const [users, setUsers] = useState([]);

  const fetchUsers = async () => {
    let response = await userServices.getAll();
    setUsers(response.data)
  }

  useEffect(() => {
    fetchUsers();
    return () => {

    }
  }, [])

  const generateSingleOptions = () => {
    return users.map((option: any) => {
      return (
        <MenuItem key={option.id} value={option.id}>
          {option.name}
        </MenuItem>
      );
    });
  };


  return (
    <FormControl size={"medium"} >

      <InputLabel> Ususarios disponibles </InputLabel>
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

