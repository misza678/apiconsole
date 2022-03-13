import classes from "../../components/AboutUs/AboutCompany.module.css";
import { Link } from "react-router-dom";
import React, { Fragment } from "react";

const CollectionService = (props) => {
  return (
    <Fragment>
      <div className={classes.SectionContainer}>
        <div className={classes.HeaderContainer}>
          <h1>SKUP KONSOL</h1>
        </div>
        <div className={classes.TextContainer}>
          <div className={classes.FirstColumn}>
            <p>
              Jeżeli znudziła Ci się Twoja konsola i chcesz jej dać drugie życie
              - sprzedaj ją nam! ConsoleStore to miejsce, w którym otrzymasz
              błyskawiczną, korzystną wycenę, bezpieczeństwo transakcji, a
              wszystko to bez wychodzenia z domu, zbędnych negocjacji i straty
              czasu. Odkupujemy konsole Playstation, Xbox oraz Nintendo. Dowiedz
              się, jak łatwo uzyskać gotówkę za sprzęt, którego już nie używasz.
              Sprawdź, jak działamy i dlaczego warto wysłać swoją konsolę
              właśnie nam. Na popularnych portalach sprzedażowych znajdują się
              setki, jeśli nie tysiące ogłoszeń dotyczących sprzedaży konsol
              PS3, PS4, Xbox. Wiele z nich z pewnością znajdzie swoich nabywców,
              jednakże obsługa zapytań i negocjacje z potencjalnym kupującym
              wiążą się z koniecznością poświecenia czasu.
            </p>
          </div>
          <div className={classes.SecondColumn}>
            <p>
              Ponadto, bezpieczeństwo takich transakcji nie jest do końca pewne.
              Aby uniknąć ryzyka, straty czasu, ponoszenia kosztów prowizji za
              sprzedaż, najlepiej handlować z nami. ConsoleStore gwarantuje
              uczciwe, atrakcyjne wyceny, błyskawiczne i w stu procentach pewne
              transakcje. Również i Ty możesz dołączyć do ich grona. Zarobione
              pieniądze możesz wydać na nowy model konsoli lub po prostu
              uzupełnić domowy budżet. Po co trzymać w domu zbędne przedmioty,
              jeśli mogą one posłużyć komuś innemu? Nasza platforma to sposób,
              by zyskać gotówkę, a jednocześnie pozbyć się sprzętu w ekologiczny
              sposób. Czekamy na Twoją konsolę i chcemy za nią zapłacić! Nie
              zwlekaj - dowiedz się, ile możesz zyskać i wypełnij formularz
              sprzedaży.
            </p>
          </div>
        </div>
        <a className={classes.Button}>
          <Link to="/skup">Sprzedaj swoją konsolę!</Link>
        </a>
      </div>
    </Fragment>
  );
};
export default CollectionService;
