import { Fragment, useState, useEffect } from "react";
import classes from "./ConsoleChoose.module.css";
import { createApiEndpoint, ENDPOINTS } from "../../api";

const ConsoleDefectChoose = (props) => {
  const { modelID, setDefectID, setStep } = props;
  const [defectList, setdefectList] = useState([]);

  useEffect(() => {
    createApiEndpoint(ENDPOINTS.Defects)
      .fetchById(modelID)
      .then((res) => {
        let defectList = res.data.map((item) => ({
          id: item.defectID,
          name: item.name,
        }));
        setdefectList(defectList);
      })
      .catch((err) => console.log(err));
  }, [modelID]);

  return (
    <Fragment>
      <div className={classes.container_console}>
        <div className={classes.h1}>
          <h1>Co nie działa?</h1>
        </div>
        <hr className={classes.margin}></hr>

        <div className={classes.menu}>
          {defectList.map((defectList) => (
            <div key={defectList.id} className={classes.block}>
              <a
                onClick={() => {
                  setDefectID(defectList.id);
                  setStep(true);
                }}
              >
                <h3 className={classes.console_name}>{defectList.name}</h3>
              </a>
            </div>
          ))}
        </div>
      </div>
    </Fragment>
  );
};

export default ConsoleDefectChoose;
