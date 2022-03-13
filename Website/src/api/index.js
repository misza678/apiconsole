import axios from "axios";
import authHeader from "../components/Authentication/AuthHeader";
const Base_url = "https://localhost:44395/api/";
export const ENDPOINTS = {
  Product: "Products",
  Defects: "DefectModels",
  Shipping: "ShippingMetods",
  Repair: "Repairs",
  Images: "Images",
  Companies: "Companies",
  Register: "Authenticate/register",
  Login: "Authenticate/login",
  Address: "Addresses",
  Customer: "Customers",
  Model: "Models",
};

export const createApiEndpoint = (endpoint) => {
  let url = Base_url + endpoint + "/";

  return {
    fetchAll: () => axios.get(url, { headers: authHeader() }),
    fetchById: (id) => axios.get(url + id, { headers: authHeader() }),

    create: (newRecord) =>
      axios.post(url, newRecord, { headers: authHeader() }),
    update: (id, updatedRecord) =>
      axios.put(url + id, updatedRecord, { headers: authHeader() }),
    delete: (id) => axios.delete(url + id, { headers: authHeader() }),
  };
};
