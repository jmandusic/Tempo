import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";

import App from "./App";
import "./index.css";
import configureAxios from "./services/axios";
import BrowserHistoryWrapper from "./utils/BrowserHistoryWrapper";
import RegularUser from "./components/Authorized/RegularUser";

configureAxios();

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      <BrowserHistoryWrapper>
        <App />
      </BrowserHistoryWrapper>
    </BrowserRouter>
  </React.StrictMode>,
  document.getElementById("root")
);
