import { Fragment, useState, useEffect } from "react";
import classes from "../../components/ConsoleRepair/ConsoleChoose.module.css";
import { createApiEndpoint, ENDPOINTS } from "../../api";

const ShippinghChoose = (props) => {
  const { setShippingID, setStep } = props;

  const [shippingList, setshippingList] = useState([]);

  useEffect(() => {
    createApiEndpoint(ENDPOINTS.Shipping)
      .fetchAll()
      .then((res) => {
        let shippingList = res.data.map((item) => ({
          id: item.shippingMetodID,
          name: item.name,
          image: item.photoSRC,
        }));
        setshippingList(shippingList);
      })
      .catch((err) => console.log(err));
  }, []);

  return (
    <Fragment>
      <div className={classes.container_console}>
        <div className={classes.h1}>
          <h1>Jak dostarczysz przedmiot?</h1>
        </div>
        <hr className={classes.margin}></hr>
        <div className={classes.menu}>
          {shippingList.map((shippingList) => (
            <div key={shippingList.id} className={classes.block}>
              <a
                onClick={() => {
                  setShippingID(shippingList.id);
                  setStep(true);
                }}
              >
                <img
                  src={
                    require("../../Content/Images/" +
                      shippingList.image +
                      ".jpg").default
                  }
                />
                <h3 className={classes.console_name}>{shippingList.name}</h3>
              </a>
            </div>
          ))}
        </div>
      </div>
    </Fragment>
  );
};

export default ShippinghChoose;
