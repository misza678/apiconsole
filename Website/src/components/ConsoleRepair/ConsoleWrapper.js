import React, { Fragment, useState, useEffect } from "react";
import classes from "../../components/ConsoleRepair/ConsoleWrapper.module.css";
import ConsoleBrand from "./ConsoleBrand";
import ProductChoose from "./ProductChoose";
import ModelChoose from "./ModelChoose";
import DefectChoose from "./DefectChoose";
import ShippingChoose from "./ShippingChoose";
import { useParams, Link } from "react-router-dom";
const ConsoleWrapper = (props) => {
  const [productID, setProductID] = useState(0);
  const [modelID, setModelID] = useState(0);
  const [defectID, setDefectID] = useState(0);
  const [shippingID, setShippingID] = useState(0);
  const [zerostep, setzerostep] = useState(false);
  const [firststep, setfirststep] = useState(false);
  const [secondstep, setsecondstep] = useState(false);
  const [thirdstep, setthirdstep] = useState(false);
  const [fourthstep, setfourthstep] = useState(false);
  let { mod } = useParams();

  useEffect(() => {
    if ((mod === "Sony") | (mod === "Microsoft") | (mod === "Nintendo")) {
      setzerostep(true);
    }
  });
  console.log(shippingID);
  return (
    <Fragment>
      <div className={classes.Wrapper}>
        <div className={classes.StageSection}>
          <div className={classes.ConsoleBrand}>
            <ConsoleBrand />
          </div>
          <div className={classes.ConsoleModel}>
            {zerostep ? (
              <ProductChoose
                whichConsole={mod}
                setProductID={setProductID}
                setStep={setfirststep}
              />
            ) : null}
          </div>
          <div className={classes.ConsoleModel}>
            {firststep ? (
              <ModelChoose
                productID={productID}
                setModelID={setModelID}
                category={"Konsola"}
                setStep={setsecondstep}
              />
            ) : null}
          </div>

          <div className={classes.ConsoleModel}>
            {secondstep ? (
              <DefectChoose
                modelID={modelID}
                setDefectID={setDefectID}
                setStep={setthirdstep}
              />
            ) : null}
          </div>

          <div className={classes.ConsoleModel}>
            {thirdstep ? (
              <ShippingChoose
                setShippingID={setShippingID}
                setStep={setfourthstep}
              />
            ) : null}
          </div>

          <div className={classes.ConsoleModel}>
            {fourthstep ? (
              <Link
                className={classes.nextStep}
                to={{
                  pathname: "/form",
                  modelid: modelID,
                  defectid: defectID,
                  shippingid: shippingID,
                }}
              >
                Przejdź dalej
              </Link>
            ) : null}
          </div>
        </div>
      </div>
    </Fragment>
  );
};

export default ConsoleWrapper;
