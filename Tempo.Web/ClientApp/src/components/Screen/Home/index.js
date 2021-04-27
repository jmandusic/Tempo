import { useUser } from "../../../providers/UserProvider/hooks";
import { useEffect, useState } from "react";
import axios from "axios";
import { Redirect, Route, Switch, useHistory } from "react-router";
import RegularUser from "../../Authorized/RegularUser";
import Employee from "../../Authorized/Employee";
import Admin from "../../Authorized/Admin";

const Home = () => {
  const history = useHistory();
  const [{ role, userId }, logOut] = useUser();

  useEffect(() => {
    if (window.location.pathname === "/home" && role) {
      history.push(`/home/${role.toLowerCase()}`);
    }
  }, [role]);

  if (!role) {
    return <div>Loading...</div>;
  }

  return (
    <Switch>
      <Route exact path="/home/regularuser">
        <RegularUser />
      </Route>

      <Route exact path="/home/mentor">
        <Employee />
      </Route>

      <Route exact path="/home/admin">
        <Admin />
      </Route>
    </Switch>
  );
};

export default Home;
