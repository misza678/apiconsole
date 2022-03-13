import "./App.css";
import Header from "./components/Layout/Header";
import { useState, useEffect } from "react";
import Footer from "./components/Layout/Footer";
import AuthService from "./components/Authentication/AuthService";
import { BrowserRouter as Router, Route, Redirect } from "react-router-dom";
import AboutUsWrapper from "./components/AboutUs/AboutUsWrapper";
import ConsoleWrapper from "./components/ConsoleRepair/ConsoleWrapper";
import OrderForm from "./components/Form/OrderFormWrapper";
import controllerwrapper from "./components/ControllerRepair/controllerWrapper";
import Contactus from "./components/ContactUs/ContactUs";
import CollectionCentreWrapper from "./components/CollectionCentre/CollectionCentreWrapper";
import Login from "./components/Authentication/Login";
import Register from "./components/Authentication/Register";
import MyAccount from "./components/MyAccount/MyAccountWrapper";
function App() {
  const [currentUser, setCurrentUser] = useState(false);
  const user = AuthService.getCurrentUser();
  useEffect(() => {
    const res = AuthService.AuthVerify();
    if (res === false) {
      setCurrentUser(true);
      console.log(currentUser);
    } else setCurrentUser(false);
  }, user);

  return (
    <Router>
      <Header user={currentUser} />

      <main>
        <Route exact path="/">
          <Redirect to="/StronaGlowna" />
        </Route>
        <Route path="/StronaGlowna" exact component={AboutUsWrapper} />
        <Route path="/konsole" exact component={ConsoleWrapper} />
        <Route path="/konsole/:mod" exact component={ConsoleWrapper} />
        <Route path="/form" exact component={OrderForm} />
        <Route path="/kontrolery" exact component={controllerwrapper} />
        <Route path="/kontrolery/:mod" exact component={controllerwrapper} />
        <Route path="/kontakt" exact component={Contactus} />
        <Route path="/skup" exact component={CollectionCentreWrapper} />
        <Route path="/skup/:mod" exact component={CollectionCentreWrapper} />
        <Route path="/konto" exact component={MyAccount} />
        <Route path="/konto/:mod" exact component={MyAccount} />
        <Route path="/login" exact component={Login} />
        <Route path="/rejestracja" exact component={Register} />
      </main>

      <Footer />
    </Router>
  );
}

export default App;
