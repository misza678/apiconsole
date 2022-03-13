import { Fragment } from "react";
import classes from "./CollectionCentreWithControler.module.css";

const WithController = (props) => {
  const { setwithController, setFourthStep } = props;

  return (
    <Fragment>
      <div className={classes.SectionContainer}>
        <div className={classes.Header}>
          <h1>Z kontrolerem?</h1>
        </div>
        <hr className={classes.Margin}></hr>
        <div className={classes.CardContainer}>
          <div className={classes.Card}>
            <a
              className={classes.Button}
              onClick={() => {
                setwithController(true);
                setFourthStep(true);
              }}
            >
              Tak
            </a>
          </div>
          <div className={classes.Card}>
            <a
              className={classes.Button}
              onClick={() => {
                setwithController(true);
                setFourthStep(true);
              }}
            >
              Nie
            </a>
          </div>
        </div>
      </div>
    </Fragment>
  );
};

export default WithController;
