import { Link, Redirect } from "react-router-dom";
import axios from "axios";
import { useState } from "react";
import { parseJwt } from "../../../utils/jwtHelper";
import { useUser } from "../../../providers/UserProvider/hooks";
import TooglePassword from "../../../assets/TooglePassword.svg";
import TempoText from "../../../assets/TempoText.svg";
import FormPicture from "../../../assets/FormPicture.svg";

import "./Login.css";

const Login = () => {
  const [{ role, userId }, setState] = useUser();
  const [backendMessage, setBackendMessage] = useState("");
  const [user, setUser] = useState({
    email: "",
    password: "",
  });

  const emailHanlder = (e) => {
    setUser((prevState) => ({ ...prevState, email: e.target.value }));
  };

  const passwordHanlder = (e) => {
    setUser((prevState) => ({ ...prevState, password: e.target.value }));
  };

  const handleTooglePassword = () => {
    const input = document.querySelector(".password");
    if (input.type === "password") {
      input.type = "text";
    } else {
      input.type = "password";
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    axios.post("api/Account/Login", user).then(
      (res) => {
        localStorage.setItem("token", res.data);
        const parsedToken = parseJwt(res.data);
        setState((prevState) => ({
          ...prevState,
          role: parsedToken.role,
          userId: parsedToken.userId,
        }));
      },
      ({ response }) => setBackendMessage(response.data)
    );
  };

  if (role) {
    return <Redirect to="/home" />;
  }

  return (
    <section className="login-layout">
      <section className="login__desktop">
        <img className="tempo" src={TempoText} />
        <img className="background" src={FormPicture} />
        <h1 className="header">
          Prati svoj <span className="underlined">Tempo</span>
        </h1>
      </section>

      <section className="section__login">
        <h2 className="login__title">Prijavi se</h2>
        <form className="login__form" onSubmit={handleSubmit}>
          <label className="form__label--login">Email</label>
          <input
            className="form__input--login"
            type="email"
            value={user.email}
            onChange={emailHanlder}
          />

          <label className="form__label--login">
            Lozinka{" "}
            <img
              className="toogle__password--login"
              alt="Toogle Password"
              src={TooglePassword}
              onClick={handleTooglePassword}
            />
          </label>
          <input
            className="form__input--login password"
            type="password"
            value={user.password}
            onChange={passwordHanlder}
          />

          <p>{backendMessage}</p>

          <button className="form__submit--login" type="submit">
            Prijavi se
          </button>
        </form>
        <Link to="/register">
          <p className="register">Još uvijek nemaš račun? Registriraj se.</p>
        </Link>
      </section>
    </section>
  );
};

export default Login;
