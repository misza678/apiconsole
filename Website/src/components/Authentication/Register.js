import React, { Fragment, useState } from "react";
import classes from "./Login.module.css";
import { createApiEndpoint, ENDPOINTS } from "../../api";
import { useForm } from "react-hook-form";
import { Link, Redirect } from "react-router-dom";
import background from "../../Content/Images/aboutusphoto3.jpg";
const Register = () => {
  const [redirect, setRedirect] = useState(false);
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const onSubmit = (data) => {
    let credentials = {
      username: data.username,
      email: data.email,
      password: data.password,
    };

    createApiEndpoint(ENDPOINTS.Register)
      .create(credentials)
      .then((response) => {
        setRedirect(true);
        console.log(response.data.message);
      })
      .catch((err) => console.log(err));
  };
  if (redirect) {
    return <Redirect to="StronaGlowna" />;
  }
  return (
    <Fragment>
      <div
        className={classes.SectionContainer}
        style={{ backgroundImage: `url(${background})` }}
      >
        <div className={classes.FormContainer}>
          <h1>Zarejestruj się!</h1>
          <form onSubmit={handleSubmit(onSubmit)}>
            {/* register your input into the hook by invoking the "register" function */}
            <input placeholder="Nazwa użytkownika" {...register("username")} />

            <input
              type="password"
              placeholder="Hasło"
              {...register("password", { required: true })}
            />
            <input
              type="password"
              placeholder="Powtórz hasło"
              {...register("password2", { required: true })}
            />
            <input
              placeholder="Email"
              type="email"
              {...register("email", { required: true })}
            />

            {errors.exampleRequired && <span>This field is required</span>}

            <input type="submit" />
          </form>
          <h2>
            Masz konto?{" "}
            <Link
              to="/login"
              style={{
                color: "#378f7b",
                textDecoration: "none",
              }}
            >
              Zaloguj się!
            </Link>
          </h2>
        </div>
      </div>
    </Fragment>
  );
};

export default Register;
