import { Fragment } from "react";
import classes from "../../components/AboutUs/Banner.module.css";
import background from "../../Content/Images/background.jpg";
import check from "../../Content/Images/check (1).png";
import { Link } from "react-router-dom";

const Banner = (props) => {
  return (
    <Fragment>
      <div
        className={classes.Background}
        style={{ backgroundImage: `url(${background})` }}
      >
        <div className={classes.Container}>
          <div className={classes.TextSection}>
            <h1>EKSPERCI W NAPRAWIE KONSOLI I KONTROLERÓW</h1>

            <h3>Wykwalifikowani i doświadczeni pracownicy:</h3>

            <p>
              <img src={check} /> 6 miesięcy gwarancji na większość napraw
            </p>
            <p>
              <img src={check} /> Ponad 10 lat doświadczenia
            </p>
            <h3>Naprawiamy:</h3>
            <p>
              <img src={check} />
              Konsole
            </p>

            <p>
              <img src={check} />
              Kontrolery
            </p>

            <a className={classes.Button}>
              <Link to="/konsole">ZLEĆ NAPRAWĘ</Link>
            </a>
            <a className={classes.ContactButton}>
              <Link to="/kontakt">KONTAKT</Link>
            </a>
          </div>
          <div className={classes.ImageSection}>
            <img
              width="512"
              alt="PlayStation 5 and DualSense with transparent background"
              src="https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/PlayStation_5_and_DualSense_with_transparent_background.png/512px-PlayStation_5_and_DualSense_with_transparent_background.png"
            ></img>
          </div>
        </div>
      </div>
    </Fragment>
  );
};

export default Banner;
