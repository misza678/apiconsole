import jwt from "jsonwebtoken";

const logout = () => {
  localStorage.removeItem("user");
};

const getCurrentUser = () => {
  console.log(JSON.parse(localStorage.getItem("user")));
  return JSON.parse(localStorage.getItem("user"));
};

const AuthVerify = () => {
  const user = getCurrentUser();
  var isExpired = false;
  if (user != null) {
    var dateNow = new Date();
    var myDate = new Date(user.expiration);
    var withOffset = myDate.getTime();
    if (withOffset < dateNow.getTime()) {
      isExpired = true;
      logout();
      console.log("wylogowano");
    }
  } else {
    console.log("użytkownik nie jest zalogowany");
    isExpired = true;
  }
  return isExpired;
};
const authService = {
  logout,
  getCurrentUser,
  AuthVerify,
};
export default authService;
