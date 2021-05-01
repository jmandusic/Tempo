import { useUser } from "../../../providers/UserProvider/hooks";
import { useEffect, useState } from "react";
import axios from "axios";
import { Redirect, Route, Switch, useHistory } from "react-router";
import RegularUser from "../../Authorized/RegularUser";
import Employee from "../../Authorized/Employee";
import Admin from "../../Authorized/Admin";

const Home = () => {
  const [{ role, userId }, setState] = useUser();

  if (!role) {
    return <Redirect to="/login" />;
  }

  return (
    <>
      {role === "RegularUser" && <RegularUser />}
      {role === "Employee" && <Employee />}
      {role === "Admin" && <Admin />}
    </>
  );
};

export default Home;
