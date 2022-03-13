import React, { Fragment, useState, useEffect } from "react";
import classes from "./MyAccountSection.module.css";
import { useForm } from "react-hook-form";
import { createApiEndpoint, ENDPOINTS } from "../../api";

const MyAccountSectionNoData = (props) => {
  const type = props.type;
  console.log(type);

  const [addressID, setAddressID] = useState(0);

  const AddAddress = (data) => {
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
        setAddressID(response.data.addressID);
      })
      .catch((err) => console.log(err));

    console.log(addressID);

    let Customer = {
      customerId: 0,
      name: data.firstName,
      lastName: data.lastName,
      email: data.email,
      phone: data.phone,
      addressID: addressID,
    };
    if (addressID != 0) {
      createApiEndpoint(ENDPOINTS.Customer)
        .create(Customer)
        .then((response) => {})
        .catch((err) => console.log(err));
    } else {
      console.log(addressID);
    }
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  return (
    <Fragment>
      <div className={classes.FormContainer}>
        <h1>Uzupełnij dane do wysyłki</h1>
        <form onSubmit={handleSubmit(AddAddress)}>
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

          {errors.exampleRequired && <span>This field is required</span>}

          <input type="submit" />
        </form>
      </div>
    </Fragment>
  );
};

export default MyAccountSectionNoData;
