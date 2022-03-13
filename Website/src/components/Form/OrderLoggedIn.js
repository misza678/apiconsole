import React, { Fragment, useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import classes from "../../components/Form/Form.module.css";
import { createApiEndpoint, ENDPOINTS } from "../../api";
import authService from "../Authentication/AuthService";
import { Link, useLocation, Redirect } from "react-router-dom";
import OrderLoginIn from "./OrderLoginIn";
const OrderForm = (props) => {
  const handle = useLocation();
  const [isloggedin, setIsloggedin] = useState(false);
  const [addressError, setAddressError] = useState(undefined);
  const [address, setAddress] = useState([]);
  const [redirect, setRedirect] = useState(false);
  const [repairSuccessful, setrepairSuccessful] = useState(false);
  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm({
    mode: "onBlur",
  });

  useEffect(() => {
    createApiEndpoint(ENDPOINTS.Customer)
      .fetchById(0)
      .then((res) => {
        let customer = res.data.map((item) => ({
          id: item.addressID,
          street: item.street,
          city: item.city,
          housenumber: item.houseNumber,
          postal: item.postalAddress,
          flat: item.flatNumber,
          name: item.name,
          lastname: item.lastName,
          phone: item.phone,
          email: item.email,
          customerid: item.customerID,
        }));
        setAddress(customer);
        console.log(address);
      })
      .catch((err) => {
        setAddressError(true);
        console.log(err);
      });
  }, isloggedin);

  const addRepair = (data) => {
    const customer = address.map((id) => id.customerid).toString();
    console.log(customer);
    let repair = {
      repairID: 0,
      modelID: handle.modelid,
      shippingMetodID: handle.shippingid,
      customerID: customer,
      defectID: handle.defectid,
      statusID: 1,
      price: 0,
      description: data.description,
    };
    createApiEndpoint(ENDPOINTS.Repair)
      .create(repair)
      .then((res) => {
        setrepairSuccessful(true);
        setIsloggedin(false);
      })
      .catch((err) => console.log(err));
  };

  useEffect(() => {
    if (authService.getCurrentUser() !== null) {
      setIsloggedin(true);
      console.log(isloggedin);
    }
  }, []);
  useEffect(() => {
    authService.AuthVerify();
  }, []);

  if (redirect) {
    return <Redirect push to="/konto/wysylka" />;
  }
  return (
    <Fragment>
      <div className={classes.Container}>
        <div className={classes.FormContainer}>
          {repairSuccessful ? (
            <h1 className={classes.Header}>Zamówienie przyjęte</h1>
          ) : null}
          {address.map((address) => (
            <form className={classes.form} onSubmit={handleSubmit(addRepair)}>
              <h2 className={classes.Header}>Sprawdź dane:</h2>
              <input
                readonly="readonly"
                placeholder="Imię:"
                defaultValue={address.name}
                id="firstName"
                {...register("firstName", { required: true })}
              />

              <input
                readonly="readonly"
                id="lastName"
                defaultValue={address.lastname}
                placeholder="Nazwisko:"
                {...register("lastName", { required: true })}
              />

              <input
                readonly="readonly"
                placeholder="Email:"
                id="email"
                defaultValue={address.email}
                {...register("email", { required: true })}
              />

              <input
                readonly="readonly"
                placeholder="Numer telefonu:"
                id="phone"
                defaultValue={address.phone}
                {...register("phone", { required: true })}
              />

              <input
                readonly="readonly"
                placeholder="Ulica:"
                id="street"
                defaultValue={address.street}
                {...register("street", { required: true })}
              />

              <input
                readonly="readonly"
                placeholder="Nr domu:"
                id="housenumber"
                defaultValue={address.housenumber}
                {...register("housenumber", { required: true })}
              />

              <input
                readonly="readonly"
                placeholder="Nr mieszkania:"
                id="flatnumber"
                defaultValue={address.flat}
                {...register("flatnumber")}
              />

              <input
                placeholder="Miasto:"
                readonly="readonly"
                id="city"
                defaultValue={address.city}
                {...register("city", { required: true })}
              />

              <input
                placeholder="Kod pocztowy:"
                readonly="readonly"
                id="postaladdress"
                defaultValue={address.postal}
                {...register("postaladdress", { required: true })}
              />
              <textarea
                id="description"
                type="text"
                placeholder="Opis usterki(opcjonalnie):"
                {...register("description")}
              />

              {errors.exampleRequired && <span>This field is required</span>}
              <div className={classes.Buttons}>
                <button
                  className={classes.Edit}
                  onClick={() => {
                    setRedirect(true);
                  }}
                >
                  Edytuj adres
                </button>
                <input type="submit" />
              </div>
            </form>
          ))}
        </div>
      </div>
    </Fragment>
  );
};

export default OrderForm;
