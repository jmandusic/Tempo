import { useEffect, useState } from "react";
import { Redirect, Route, Switch } from "react-router";

import LandingPage from "./components/LandingPage";
import Home from "./components/Screen/Home";
import Login from "./components/Screen/Login";
import Register from "./components/Screen/Register";
import GymProvider from "./providers/GymProvider";
import UserProvider from "./providers/UserProvider";

const App = () => {
  return (
    <UserProvider>
      <Switch>
        <Route exact path="/login">
          <Login />
        </Route>

        <Route exact path="/register">
          <Register />
        </Route>

        <Route exact path="/home">
          <GymProvider>
            <Home />
          </GymProvider>
        </Route>

        <Redirect to="/home" />
      </Switch>
    </UserProvider>
  );
};

export default App;
