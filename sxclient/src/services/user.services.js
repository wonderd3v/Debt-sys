import http from "../axios/http.common";

const getAll = async () => {
  return await http.get("/Users");
};

const OdataQuerys = async ( typeOfQuery, query ) => {
  return await http.get(`/Users/Query?$${typeOfQuery}${query}`);
}

const getById = async id => {
  return await http.get(`/Users/${id}`);
};

const getNameById = async id => {
  let request = await http.get(`/Users/${id}`)
  let response = request.data;


  return response.name;
};


const create = data => {
  return http.post("/Users", data);
};

const update = (id, data) => {
  return http.put(`/Users/${id}`, data);
};

const remove = id => {
  return http.delete(`/Users/${id}`);
};

const removeAll = () => {
  return http.delete(`/Users`);
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
  getNameById

};