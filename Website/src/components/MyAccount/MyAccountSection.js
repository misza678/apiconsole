import React, { Fragment, useState, useEffect } from "react";
import classes from "./MyAccountSection.module.css";
import { useForm } from "react-hook-form";
import { createApiEndpoint, ENDPOINTS } from "../../api";
import MyAccountNoData from "./MyAccountNoData";
const MyAccountSection = (props) => {
  const type = props.type;
  console.log(type);

  const [address, setAddress] = useState([]);
  const editAddress = (data) => {
    const customer = address.map((id) => id.customerid).toString();
    const adressid = address.map((id) => id.id).toString();
    let Customer = {
      customerId: customer,
      name: data.firstName,
      lastName: data.lastName,
      email: data.email,
      phone: data.phone,
      addressID: adressid,
    };
    let newaddress = {
      addressID: adressid,
      city: data.city,
      postalAddress: data.postaladdress,
      street: data.street,
      houseNumber: data.housenumber,
      flatNumber: data.flatnumber,
    };
    createApiEndpoint(ENDPOINTS.Customer)
      .update(customer, Customer)
      .then((response) => {
        console.log(response.data.token);
      })
      .catch((err) => console.log(err));

    createApiEndpoint(ENDPOINTS.Address)
      .update(adressid, newaddress)
      .then((response) => {
        console.log(response.data.token);
      })
      .catch((err) => console.log(err));
  };

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
        console.log(err);
      });
  }, address === 0);

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  return (
    <Fragment>
      <section className={classes.MainSection}>
        {type === "naprawy" ? (
          <div className={classes.Container}>sdf</div>
        ) : null}
        {type === "skup" ? <div className={classes.Container}></div> : null}
        {type === "wysylka" ? <MyAccountNoData /> : null}
      </section>
    </Fragment>
  );
};

export default MyAccountSection;
