import { useUser } from "../../../providers/UserProvider/hooks";
import { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import axios from "axios";
import { Redirect, Route, Switch } from "react-router";

const Home = () => {
  const history = useHistory();
  const [{ role, userId }, logOut] = useUser();
  const [userInfo, setUserInfo] = useState({});

  useEffect(() => {
    if (window.location.pathname === "/home" && role) {
        history.push(`/home/${role.toLowerCase()}`);
        console.log(window.location.pathname);
    }
    axios.get("api/Account").then(({ data }) => setUserInfo(data));
  }, []);

  if (!role) {
    return <div>Loading...</div>;
  }

  return (
    <Switch>
      <Route exact path="/home/regularuser">
        <div>Regular user</div>
      </Route>
      <Route exact path="/home/mentor">
        <div>Employee</div>
      </Route>
      <Route exact path="/home/admin">
        <div>Admin</div>
      </Route>
    </Switch>
  );
};

export default Home;
