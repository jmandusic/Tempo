import { useUser } from "../../../providers/UserProvider/hooks";
import { useEffect, useState } from "react";
import axios from "axios";
import { Redirect, Route, Switch, useHistory } from "react-router";
import { parseJwt } from "../../../utils/jwtHelper";
import RegularUser from "../../Authorized/RegularUser";
import Employee from "../../Authorized/Employee";
import Admin from "../../Authorized/Admin";

const token = localStorage.getItem("token");
const tokenParsed = parseJwt(token);

const initialState = {
    role: tokenParsed?.role,
    userId: tokenParsed?.userId,
};

const Home = () => {
  const history = useHistory();
  const [role, setRole] = useState(initialState.role);
  const [userInfo, setUserInfo] = useState();

  useEffect(() => {
    console.log("Role: " + role);
    if (window.location.pathname === "/home" && role) {
      history.push(`/home/${role.toLowerCase()}`);
    }
    axios.get("api/Account").then((res) => setUserInfo(res.data));
  }, [role]);

  if (!role) {
    return <div>Loading...</div>;
  }

  return (
    <Switch>
      <Route exact path="/home/regularuser">
        <RegularUser user={userInfo}/>
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
