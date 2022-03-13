import React, { Fragment, useState } from "react";
import { createApiEndpoint, ENDPOINTS } from "../../api";
import classes from "./Login.module.css";
import { Link, Redirect } from "react-router-dom";
import { useForm } from "react-hook-form";
import background from "../../Content/Images/aboutusphoto3.jpg";
const Login = (props) => {
  const [redirect, setRedirect] = useState(false);

  const onSubmit = (data) => {
    let credentials = {
      username: data.username,
      password: data.password,
    };

    createApiEndpoint(ENDPOINTS.Login)
      .create(credentials)
      .then((response) => {
        console.log(response.data.token);
        setRedirect(true);
        if (response.data.token) {
          localStorage.setItem("user", JSON.stringify(response.data));
        }

        return response.data;
      })
      .catch((err) => console.log(err));
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();
  if (redirect) {
    return <Redirect push to="/" />;
  }
  return (
    <Fragment>
      <div
        className={classes.SectionContainer}
        style={{ backgroundImage: `url(${background})` }}
      >
        <div className={classes.FormContainer}>
          <h1>Zaloguj się!</h1>
          <form onSubmit={handleSubmit(onSubmit)}>
            {/* register your input into the hook by invoking the "register" function */}
            <input placeholder="Nazwa użytkownika" {...register("username")} />

            {/* include validation with required or other standard HTML validation rules */}
            <input
              placeholder="Hasło"
              type="password"
              {...register("password", { required: true })}
            />
            {/* errors will return when field validation fails  */}
            {errors.exampleRequired && <span>This field is required</span>}

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
    </Fragment>
  );
};

export default Login;
