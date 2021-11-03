import http from "../axios/http.common";

const getAll = async () => {
  return await http.get("/Payment");
};

const OdataQuerys = async ( typeOfQuery, query ) => {
  return await http.get(`/Payment/Query?$${typeOfQuery}${query}`);
}

const getById = async id => {
  return await http.get(`/Payment/${id}`);
};

const create = data => {
  return http.post("/Payment", data);
};

const update = (id, data) => {
  return http.put(`/Payment/${id}`, data);
};

const remove = id => {
  return http.delete(`/Payment/${id}`);
};

const removeAll = () => {
  return http.delete(`/Payment`);
};



// eslint-disable-next-line import/no-anonymous-default-export
export default {
  getAll,
  getById,
  create,
  update,
  remove,
  removeAll,
  OdataQuerys,

};