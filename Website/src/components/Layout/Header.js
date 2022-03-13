import { Fragment, useEffect, useState } from "react";
import classes from "../../components/Layout/header.module.css";
import { Link } from "react-router-dom";
import authService from "../Authentication/AuthService";
const Header = (props) => {
  return (
    <Fragment>
      <header className={classes.header}>
        <nav>
          <Link className={classes.headerLogo} to="/StronaGlowna">
            ConsoleStore
          </Link>
          <div className={classes.menu}>
            <ul>
              <li>
                <Link to="/konsole">KONSOLE</Link>
              </li>
              <li>
                <Link to="/kontrolery">KONTROLERY</Link>
              </li>

              <li>
                <Link to="/skup">SKUP</Link>
              </li>
              <li>
                <Link to="/kontakt">KONTAKT</Link>
              </li>

              {props.user ? (
                <li className={classes.Account}>
                  <Link to="/konto">MOJE KONTO</Link>
                </li>
              ) : (
                <li className={classes.Account}>
                  <Link to="/login">ZALOGUJ SIĘ</Link>
                </li>
              )}
            </ul>
          </div>
        </nav>
      </header>
    </Fragment>
  );
};

export default Header;
