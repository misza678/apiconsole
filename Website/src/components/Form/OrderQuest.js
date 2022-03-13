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
  const [redirect, setRedirect] = useState(false);
  const [repairSuccessful, setrepairSuccessful] = useState(false);
  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm({
    mode: "onBlur",
  });

  const addRepairAsQuest = (data) => {
    const addressID = 0;
    const CustomerID = 0;
    let newaddress = {
      addressID: 0,
      city: data.city,
      postalAddress: data.postaladdress,
      street: data.street,
      houseNumber: data.housenumber,
      flatNumber: data.flatnumber,
    };

    createApiEndpoint(ENDPOINTS.Address)
      .create(newaddress)
      .then((response) => {
        addressID = response.data.addressID;
      })
      .catch((err) => console.log(err));

    let Customer = {
      customerId: 0,
      name: data.firstName,
      lastName: data.lastName,
      email: data.email,
      phone: data.phone,
      addressID: addressID,
    };
    createApiEndpoint(ENDPOINTS.Customer)
      .create(Customer)
      .then((response) => {
        CustomerID = response.data.customerID;
      })
      .catch((err) => console.log(err));

    let repair = {
      repairID: 0,
      productID: handle.modelid,
      shippingMetodID: handle.shippingid,
      customerID: CustomerID,
      defectID: handle.defectid,
      price: 0,
      description: data.description,
    };
    createApiEndpoint(ENDPOINTS.Repair)
      .create(repair)
      .then((res) => {})
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
          <form
            className={classes.form}
            onSubmit={handleSubmit(addRepairAsQuest)}
          >
            <h2 className={classes.Header}>Kontynuuj jako gość:</h2>
            <input
              placeholder="Imię:"
              id="firstName"
              {...register("firstName", { required: true })}
            />

            <input
              id="lastName"
              placeholder="Nazwisko:"
              {...register("lastName", { required: true })}
            />

            <input
              placeholder="Email:"
              id="email"
              {...register("email", { required: true })}
            />

            <input
              placeholder="Numer telefonu:"
              id="phone"
              {...register("phone", { required: true })}
            />

            <input
              placeholder="Ulica:"
              id="street"
              {...register("street", { required: true })}
            />

            <input
              placeholder="Nr domu:"
              id="housenumber"
              {...register("housenumber", { required: true })}
            />

            <input
              placeholder="Nr mieszkania:"
              id="flatnumber"
              {...register("flatnumber")}
            />

            <input
              placeholder="Miasto:"
              id="city"
              {...register("city", { required: true })}
            />

            <input
              placeholder="Kod pocztowy:"
              id="postaladdress"
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
        </div>
      </div>
    </Fragment>
  );
};

export default OrderForm;
