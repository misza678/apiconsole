import { Fragment } from "react";
import classes from "../../components/CollectionCentre/CollectionCentreCategory.module.css";
import { BsController } from "react-icons/bs";
import { GiGameConsole } from "react-icons/gi";

const CollectionCentreCategory = (props) => {
  const { setCategoryId, setFirstStep } = props;

  return (
    <Fragment>
      <section className={classes.container}>
        <div className={classes.header}>
          <h1>Co chcesz sprzedać?</h1>
          <hr className={classes.marginCC}></hr>
        </div>

        <div className={classes.buttons}>
          <button
            onClick={() => {
              setCategoryId(2);
              setFirstStep(true);
            }}
          >
            <span className={classes.title}>Kontroler</span>
            <BsController size="150px" />
          </button>
          <button
            id={classes.rightbtn}
            onClick={() => {
              setCategoryId(1);
              setFirstStep(true);
            }}
          >
            <span className={classes.title}>Konsola</span>
            <GiGameConsole size="150px" />
          </button>
        </div>
      </section>
    </Fragment>
  );
};

export default CollectionCentreCategory;
