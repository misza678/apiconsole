import { Fragment, useState, useEffect } from "react";
import classes from "../../components/ConsoleRepair/ConsoleChoose.module.css";
import { createApiEndpoint, ENDPOINTS } from "../../api";

const Controller2stage = (props) => {
  const { whichmodel, categoryid, classChange, setFourthStep } = props;
  const [consoleList, setconsoleList] = useState([]);

  useEffect(() => {
    createApiEndpoint(ENDPOINTS.ProductsToViews)
      .fetchById(whichmodel + "?category=" + categoryid)
      .then((res) => {
        let consoleList = res.data.map((item) => ({
          id: item.modlesToViewId,
          consolename: item.name,
          image: item.photoSRC,
          defectid: item.defectType,
        }));
        setconsoleList(consoleList);
      })
      .catch((err) => console.log(err));
  }, [whichmodel > 0]);

  return (
    <Fragment>
      <div
        className={
          classChange ? classes.container_consoleCC : classes.container_console
        }
      >
        <div className={classChange ? classes.h1CC : classes.h1}>
          <h1>Jaki model?</h1>
        </div>
        {classChange ? null : (
          <hr className={classChange ? classes.marginCC : classes.margin}></hr>
        )}

        <div className={classChange ? classes.menuCC : classes.menu}>
          {consoleList.map((whichmodel) => (
            <div
              key={whichmodel.id}
              className={classChange ? classes.blockCC : classes.block}
            >
              <a
                onClick={() => {
                  whichmodel(whichmodel.id);
                  setFourthStep(true);
                }}
              >
                <img
                  src={
                    require("../../Content/Images/" + whichmodel.image + ".jpg")
                      .default
                  }
                />
                <h3
                  className={
                    classChange ? classes.console_nameCC : classes.console_name
                  }
                >
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

export default Controller2stage;
