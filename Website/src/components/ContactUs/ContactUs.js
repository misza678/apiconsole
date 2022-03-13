import React, { Fragment, useEffect } from "react";
import classes from "../ContactUs/ContactUs.module.css";
import { useForm } from "react-hook-form";
import background from "../../Content/Images/background.jpg";
import authService from "../Authentication/AuthService";
import emailjs from "@emailjs/browser";

const ContactUs = (props) => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const EmailSend = (data) => {
    const templateParams = {
      name: data.firstName,
      lastname: data.lastName,
      message: data.message,
      email: data.email,
    };

    emailjs
      .send(
        "service_2czfcnm",
        "template_2agzleg",
        templateParams,
        "KDz00jkvZpLW3ZnGY"
      )
      .then(
        (response) => {
          console.log("SUCCESS!", response.status, response.text);
        },
        (err) => {
          console.log("FAILED...", err);
        }
      );
  };

  return (
    <Fragment>
      <div className={classes.SectionContainer}>
        <div style={{ backgroundImage: `url(${background})` }}>
          <h1 className={classes.header}>Skontaktuj się z nami:</h1>
        </div>
        <div className={classes.container}>
          <form className={classes.form} onSubmit={handleSubmit(EmailSend)}>
            <div className={classes.name}>
              <fieldset>
                <label htmlFor="firstName">
                  Imię<span className={classes.star}>*</span>
                </label>
                <input
                  id="firstName"
                  {...register("firstName", { required: true })}
                />
              </fieldset>
              <fieldset>
                <label htmlFor="lastName">
                  Nazwisko<span className={classes.star}>*</span>
                </label>
                <input
                  id="lastName"
                  {...register("lastName", { required: true })}
                />
              </fieldset>
            </div>
            <fieldset>
              <label htmlFor="email">
                Email<span className={classes.star}>*</span>
              </label>
              <input id="email" {...register("email", { required: true })} />
            </fieldset>
            <fieldset>
              <label htmlFor="text">
                Wiadomość<span className={classes.star}>*</span>
              </label>
              <textarea
                id="text"
                {...register("message", { required: true })}
              />
            </fieldset>

            {errors.exampleRequired && <span>This field is required</span>}

            <input
              className={classes.button}
              type="submit"
              value="Wyślij wiadomość"
            />
          </form>
          <div className={classes.Info}>
            <h1>Najczęściej zadawane pytania:</h1>
            <div className={classes.qcontainer}>
              <div className={classes.question}>
                <p>Jak przygotować paczkę? </p>
                <hr className={classes.margin}></hr>
              </div>
              <div className={classes.question}>
                <p>Jak zlożyć zamówienie? </p>
                <hr className={classes.margin}></hr>
              </div>
              <div className={classes.question}>
                <p>Ile trwa naprawa? </p>
                <hr className={classes.margin}></hr>
              </div>
              <div className={classes.question}>
                <p>Jak działa skup? </p>
                <hr className={classes.margin}></hr>
              </div>
            </div>
          </div>
        </div>
      </div>
    </Fragment>
  );
};

export default ContactUs;
