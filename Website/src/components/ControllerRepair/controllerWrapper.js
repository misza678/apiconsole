import React, { Fragment, Suspense, useRef, useState, useEffect } from "react";
import classes from "../ConsoleRepair/ConsoleWrapper.module.css";
import { Link } from "react-scroll";
import ProductChoose from "../ConsoleRepair/ProductChoose";
import DefectChoose from "../ConsoleRepair/DefectChoose";
import ControllerChoose from "./ControllerChoose";
import ShippingChoose from "../ConsoleRepair/ShippingChoose";
import { useParams } from "react-router-dom";
import ControllerBrand from "./ControllerBrand";
const ControllerWrapper = (props) => {
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
  return (
    <Fragment>
      <div className={classes.Wrapper}>
        <div className={classes.StageSection}>
          <div className={classes.ConsoleBrand}>
            <ControllerBrand />
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
              <ControllerChoose
                productID={productID}
                setModelID={setModelID}
                category={"Kontroler"}
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

export default ControllerWrapper;
