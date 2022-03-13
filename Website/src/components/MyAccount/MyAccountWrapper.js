import { Fragment } from "react";
import classes from "./MyAccountWrapper.module.css";
import MyAccountMenu from "./MyAccountMenu";
import MyAccountSection from "./MyAccountSection";
import { useParams } from "react-router-dom";
const MyAccount = (props) => {
  let { mod } = useParams();
  console.log(mod);

  return (
    <Fragment>
      <section className={classes.Background}>
        <div className={classes.MainSection}>
          <MyAccountMenu />
          <MyAccountSection type={mod} />
        </div>
      </section>
    </Fragment>
  );
};

export default MyAccount;
