import classes from "../../components/AboutUs/AboutCompany.module.css";
import React, { Fragment } from "react";

const AboutCompany = (props) => {
  return (
    <Fragment>
      <div className={classes.SectionContainer}>
        <div className={classes.HeaderContainer}>
          <h1>ConsoleStore Warszawa</h1>
        </div>
        <div className={classes.TextContainer}>
          <div className={classes.FirstColumn}>
            <p>
              Podejmujemy się napraw konsol do gier - zarówno stacjonarnych, jak
              i przenośnych. Dysponujemy doskonałym warsztatem technicznym,
              elektronicznym, jesteśmy w stanie podjąć się najtrudniejszych
              napraw elektroniki. Jesteśmy biegli w lutowaniu BGA, wymianie
              chipsetów grafiki, jesteśmy również w stanie wykonać dowolną
              wymianę podzespołów, jak również przeprowadzić konserwację
              konsoli, czyszczenie układu chłodzenia, wymianę past
              termoprzewodzących. Posiadamy świetnie rozwinięte działy napraw
              laptopów oraz telefonów/tabletów/smartfonów - w związku z czym
              dysponujemy doskonałym zapleczem warsztatowo-sprzętowym oraz
              szerokim dostępem do podzespołów i części zamiennych.
            </p>
          </div>
          <div className={classes.SecondColumn}>
            <p>
              Zajmujemy się naprawą konsol do gier. Serwisujemy urządzenia
              wszystkich producentów. To wszystko pozwala nam bez problemu
              wykonywać naprawy proste oraz złożone konsol stacjonarnych, takich
              jak Xbox, czy Playstation, a także przenośnych - jak Nintendo
              Switch. IVITER Serwis to serwis konsol z prawdziwego zdarzenia.
              Oddając do nas urządzenie nie musisz niczego się obawiać, ponieważ
              trafiło w ręce prawdziwych specjalistów. Jesteśmy w stanie uporać
              się z dosłownie każdą usterką konsoli – bez względu na jej wiek
              czy stan użytkowania.
            </p>
          </div>
        </div>
      </div>
    </Fragment>
  );
};
export default AboutCompany;
