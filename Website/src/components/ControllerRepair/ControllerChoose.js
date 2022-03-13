import { Fragment, useState, useEffect } from "react";
import classes from "../../components/ConsoleRepair/ConsoleChoose.module.css";
import { createApiEndpoint, ENDPOINTS } from "../../api";

const ControllerChoose = (props) => {
  const { productID, setModelID, category, setStep } = props;
  const [consoleList, setconsoleList] = useState([]);

  useEffect(() => {
    createApiEndpoint(ENDPOINTS.Model)
      .fetchById(productID + "/" + category)
      .then((res) => {
        let consoleList = res.data.map((item) => ({
          id: item.modelID,
          consolename: item.name,
          image: item.photoSRC,
          defectid: item.defectType,
        }));
        setconsoleList(consoleList);
      })
      .catch((err) => console.log(err));
  }, [productID]);

  return (
    <Fragment>
      <div className={classes.container_console}>
        <div className={classes.h1}>
          <h1>Jaka wersja?</h1>
        </div>
        <hr className={classes.margin}></hr>

        <div className={classes.menu}>
          {consoleList.map((whichmodel) => (
            <div key={whichmodel.id} className={classes.block}>
              <a
                onClick={() => {
                  setModelID(whichmodel.id);
                  setStep(true);
                }}
              >
                <img
                  src={
                    require("../../Content/Images/" + whichmodel.image + ".jpg")
                      .default
                  }
                />
                <h3 className={classes.console_name}>
                  {whichmodel.consolename}
                </h3>
              </a>
            </div>
          ))}
        </div>
      </div>
    </Fragment>
  );
};

export default ControllerChoose;
