import { Fragment } from "react";
import classes from "./MyAccountMenu.module.css";
const MyAccountMenu = (props) => {
  return (
    <Fragment>
      <section className={classes.MainSection}>
        <div>
          <table>
            <tbody>
              <tr className={classes.Table}>
                <th>
                  <a href="/konto/naprawy">Moje zlecenia naprawy</a>
                </th>
                <th>
                  <a href="/konto/skup">Moje zlecenia wyceny</a>
                </th>
                <th>
                  <a href="/konto/wysylka">Dane do wysyłki</a>
                </th>
              </tr>
            </tbody>
          </table>
        </div>
      </section>
    </Fragment>
  );
};

export default MyAccountMenu;
