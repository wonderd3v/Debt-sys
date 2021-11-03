import http from "../axios/http.common";

const getAll = async () => {
  return await http.get("/Loan");
};

const get = async id => {
  return await http.get(`/Loan/${id}`);
};

const create = async data => {
  return await http.post("/Loan", data);
};

const update = (id, data) => {
  return http.put(`/Loan/${id}`, data);
};

const remove = id => {
  return http.delete(`/Loan/${id}`);
};

const removeAll = () => {
  return http.delete(`/Loan`);
};

const OdataQuerys = async ( typeOfQuery, query ) => {
  return await http.get(`/Loan/Query?$${typeOfQuery}${query}`);
}

// TODO: Arreglar la consulta para que retorne cualquier id

const getCreditorId = async () => {
  let result =  OdataQuerys('select','=CreditorId');
  
  return await result;
}

const getDebtorId = async () => {
  let result = await OdataQuerys('select','=DebtorId');
  
  return await result;
}

// eslint-disable-next-line import/no-anonymous-default-export
export default {
  getAll,
  get,
  create,
  update,
  remove,
  removeAll,
  OdataQuerys,
  getCreditorId,
  getDebtorId
 
};