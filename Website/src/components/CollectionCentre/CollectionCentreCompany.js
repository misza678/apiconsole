import classes from "../ConsoleRepair/ConsoleBrand.module.css";
import { createApiEndpoint, ENDPOINTS } from "../../api";
import React, { Fragment, useState, useEffect } from "react";

const ChooseBrandRepair = (props) => {
  const [companieslist, setCompanieslist] = useState([]);
  const { setCompany, setSecondStep } = props;
  useEffect(() => {
    createApiEndpoint(ENDPOINTS.Companies)
      .fetchAll()
      .then((res) => {
        let companieslist = res.data.map((item) => ({
          id: item.companyID,
          name: item.name,
        }));
        setCompanieslist(companieslist);
      })
      .catch((err) => console.log(err));
  }, [companieslist == [0]]);

  return (
    <Fragment>
      <h1 className={classes.Header}>Wybierz producenta konsoli:</h1>
      <div className={classes.CompanyContainer}>
        {companieslist.map((companies) => (
          <div className={classes.Logo} key={companies.id}>
            <a
              className={classes.Card}
              onClick={() => {
                setSecondStep(true);
                setCompany(companies.name);
              }}
            >
              <img
                src={
                  require("../../Content/Images/" + companies.name + ".png")
                    .default
                }
              />
            </a>
            <h1>{companies.name}</h1>
          </div>
        ))}
      </div>
    </Fragment>
  );
};

export default ChooseBrandRepair;
