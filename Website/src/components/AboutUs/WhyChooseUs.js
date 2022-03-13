import classes from "../../components/AboutUs/WhyChooseUs.module.css";
import React, { Fragment } from "react";

const AboutCompany = (props) => {
  return (
    <Fragment>
      <div className={classes.SectionContainer}>
        <div className={classes.HeaderContainer}>
          <h1>Dlaczego warto wybrać naszą firmę?</h1>
        </div>
        <div className={classes.CardContainer}>
          <div className={classes.Card}>
            <h1>Usługa wysyłkowa</h1>
            <p>
              Wyślij do nas swoją konsolę za darmo! Naprawimy ją i odeślemy.
            </p>
          </div>
          <div className={classes.Card}>
            <h1>6 miesięcy gwarancji</h1>
            <p>Na większośc napraw oferujemy 6 miesięcy gwarancji.</p>
          </div>
          <div className={classes.Card}>
            <h1>No fix - no Fee</h1>
            <p>
              Jeśli nie będziemy w stanie naprawić Twojej konsoli, zaproponujemy
              odkupienie na korzystnych dla Ciebie warunkach.
            </p>
          </div>
          <div className={classes.Card}>
            <h1>10 lat doświadczenia</h1>
            <p>
              Nasza firma specjalizuje się w naprawach konsoli już od 10 lat.
            </p>
          </div>
          <div className={classes.Card}>
            <h1>Śledzenie statusu zamówienia</h1>
            <p>
              Dostaniesz powiadomienia email, jeśli zmienimy status Twojego
              zlecenia.
            </p>
          </div>
          <div className={classes.Card}>
            <h1>Usługa Express</h1>
            <p>Niektóre naprawy wykonujemy w ciągu 2 godzin.</p>
          </div>
        </div>
      </div>
    </Fragment>
  );
};
export default AboutCompany;
