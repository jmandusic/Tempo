import { useEffect, useState } from "react";
import { Redirect, Route, Switch } from "react-router";

import LandingPage from "./components/LandingPage";

const App = () => {
  const [screen, setScreen] = useState(false);

  useEffect(() => {
    setTimeout(() => {
      setScreen(true);
    }, 5000);
  }, []);

  if (!screen) {
    return <LandingPage />;
  }

  return (
    <Switch>
      <Route exact path="/login">
        <div>Login</div>
      </Route>
      <Route exact path="/register">
        <div>Register</div>
      </Route>
      <Route path="/home">
        <div>Home</div>
      </Route>
      <Redirect to="/home" />
    </Switch>
  );
};

export default App;
