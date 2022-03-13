import React, { Fragment, useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import classes from "../../components/Form/Form.module.css";
import { createApiEndpoint, ENDPOINTS } from "../../api";
import authService from "../Authentication/AuthService";
import { Link, useLocation, Redirect } from "react-router-dom";
import OrderLoginIn from "./OrderLoginIn";
import OrderLoggedIn from "./OrderLoggedIn";
import OrderQuest from "./OrderQuest";
const OrderForm = (props) => {
  const handle = useLocation();
  const [isloggedin, setIsloggedin] = useState(false);
  const [addressError, setAddressError] = useState(undefined);
  const [repairSuccessful, setrepairSuccessful] = useState(false);

  useEffect(() => {
    if (authService.getCurrentUser() !== null) {
      setIsloggedin(true);
    }
  }, []);
  useEffect(() => {
    authService.AuthVerify();
  }, []);

  return (
    <Fragment>
      <div className={classes.Container}>
        <div className={classes.FormContainer}>
          {repairSuccessful ? (
            <h1 className={classes.Header}>Zamówienie przyjęte</h1>
          ) : null}
          {isloggedin ? <OrderLoggedIn /> : <OrderQuest />}
        </div>
        {addressError ? <OrderLoginIn setIsloggedin={setIsloggedin} /> : null}
      </div>
    </Fragment>
  );
};

export default OrderForm;
