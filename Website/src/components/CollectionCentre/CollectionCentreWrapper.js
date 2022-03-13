import { Fragment, useState } from "react";
import ProductChoose from "../ConsoleRepair/ProductChoose";
import classes from "../ConsoleRepair/ConsoleWrapper.module.css";
import CollectionCentreWithController from "./CollectionCentreWithController";
import CollectionCentreCategory from "../CollectionCentre/CollectionCentreCategory";
import CollectionCentreCompany from "../CollectionCentre/CollectionCentreCompany";
import CollectionCentreControllers from "./CollectionCentreControllers";
import CollectionCentreImages from "./CollectionCentreImages";
import ModelChoose from "../ConsoleRepair/ModelChoose";

const CollectionCentre = (props) => {
  const [firststep, setFirstStep] = useState(false);
  const [secondstep, setSecondStep] = useState(false);
  const [modelID, setModelID] = useState(0);
  const [thirdstep, setStep] = useState(false);
  const [fourthstep, setFourthStep] = useState(false);
  const [company, setCompany] = useState();
  const [category, setCategoryId] = useState();
  const [mod, setmod] = useState();
  const [consoleid, setConsoleId] = useState(0);
  const [withController, setwithController] = useState(false);
  return (
    <Fragment>
      <div className={classes.Wrapper}>
        <div className={classes.StageSection}>
          <div className={classes.ConsoleModel}>
            <CollectionCentreCategory
              setCategoryId={setCategoryId}
              setFirstStep={setFirstStep}
            />
          </div>

          <div className={classes.ConsoleBrand}>
            {firststep ? (
              <CollectionCentreCompany
                setCompany={setCompany}
                setSecondStep={setSecondStep}
              />
            ) : null}
          </div>
          <div className={classes.ConsoleModel}>
            {secondstep ? (
              <ProductChoose
                whichConsole={company}
                setProductID={setConsoleId}
                setStep={setStep}
              />
            ) : null}
          </div>

          <div className={classes.ConsoleModel}>
            {thirdstep & (category == 1) ? (
              <CollectionCentreWithController
                setwithController={setwithController}
                setFourthStep={setFourthStep}
              />
            ) : null}
          </div>

          <div className={classes.ConsoleModel}>
            {thirdstep & (category == 2) ? (
              <ModelChoose
                productID={consoleid}
                setModelID={setModelID}
                category={"Konsola"}
                setStep={setFourthStep}
              />
            ) : null}
          </div>

          <div className={classes.ConsoleModel}>
            {fourthstep ? <CollectionCentreImages /> : null}
          </div>
        </div>
      </div>
    </Fragment>
  );
};

export default CollectionCentre;
