import React, { Fragment, useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import classes from "../../components/Form/Form.module.css";
import { createApiEndpoint, ENDPOINTS } from "../../api";
import authService from "../Authentication/AuthService";
import { Link, useLocation, Redirect } from "react-router-dom";
const OrderForm = (props) => {
  const { setIsloggedin } = props;

  const {
    register: register2,
    formState: { errors: errors2 },
    handleSubmit: handleSubmit2,
  } = useForm({
    mode: "onBlur",
  });

  const onSubmit = (data) => {
    let credentials = {
      username: data.username,
      password: data.password,
    };

    createApiEndpoint(ENDPOINTS.Login)
      .create(credentials)
      .then((response) => {
        if (response.data.token) {
          localStorage.setItem("user", JSON.stringify(response.data));
          setIsloggedin(true);
        }
        return response.data;
      })
      .catch((err) => console.log(err));
  };

  return (
    <Fragment>
      <div className={classes.Container}>
        <div className={classes.FormContainer}>
          <div className={classes.Login}>
            <h2>Masz konto? Zaloguj się!</h2>
            <div className={classes.FormContainer}>
              <form key={2} onSubmit={handleSubmit2(onSubmit)}>
                {/* register your input into the hook by invoking the "register" function */}
                <input
                  placeholder="Nazwa użytkownika"
                  {...register2("username")}
                />

                {/* include validation with required or other standard HTML validation rules */}
                <input
                  placeholder="Hasło"
                  type="password"
                  {...register2("password", { required: true })}
                />
                {/* errors will return when field validation fails  */}
                {errors2.exampleRequired && <span>This field is required</span>}

                <input type="submit" />
              </form>
              <h2>
                Nie masz konta?{" "}
                <Link
                  to="/rejestracja"
                  style={{
                    color: "#378f7b",
                    textDecoration: "none",
                  }}
                >
                  Zarejestruj się!
                </Link>
              </h2>
            </div>
          </div>
        </div>
      </div>
    </Fragment>
  );
};

export default OrderForm;
