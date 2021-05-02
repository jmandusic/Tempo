import axios from "axios";
import { useState } from "react";
import { Link, Redirect } from "react-router-dom";
import { parseJwt } from "../../../utils/jwtHelper";
import { useUser } from "../../../providers/UserProvider/hooks";
import TooglePassword from "../../../assets/TooglePassword.svg";
import "./Register.css";

const Register = () => {
  const [{ role, userId }, setState] = useUser();
  const [repatedPassword, setRepeatedPassword] = useState("");
  const [backendMessage, setBackendMessage] = useState("");
  const [user, setUser] = useState({
    name: "",
    email: "",
    password: "",
  });

  const nameHanlder = (e) => {
    setUser((prevState) => ({ ...prevState, name: e.target.value }));
  };

  const emailHanlder = (e) => {
    setUser((prevState) => ({ ...prevState, email: e.target.value }));
  };

  const passwordHanlder = (e) => {
    setUser((prevState) => ({ ...prevState, password: e.target.value }));
  };

  const repatedPasswordHandler = (e) => {
    setRepeatedPassword(e.target.value);
  };

  const handleTooglePassword = (id) => {
    const input = document.querySelector(`.password${id}`);
    if (input.type === "password") {
      input.type = "text";
    } else {
      input.type = "password";
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (user.password !== repatedPassword) {
      return;
    }

    axios.post("api/Account/RegisterRegularUser", user).then(
      (res) => {
        localStorage.setItem("token", res.data);
        const parsedToken = parseJwt(res.data);
        setState((prevState) => ({
          ...prevState,
          role: parsedToken.role,
          userId: parsedToken.userId,
        }));
      },
      ({ response }) => {
        setBackendMessage(response.data);
      }
    );
  };

  if (role) {
    return <Redirect to="/home" />;
  }

  return (
    <section className="section__register">
      <h2 className="register__title">Registriraj se</h2>
      <form className="register__form" onSubmit={handleSubmit}>
        <label className="form__label--register">Korisničko ime</label>
        <input
          className="form__input--register"
          required
          type="text"
          onChange={nameHanlder}
          value={user.name}
        />

        <label className="form__label--register">Email</label>
        <input
          className="form__input--register"
          required
          type="email"
          onChange={emailHanlder}
          value={user.email}
        />

        <label className="form__label--register">
          Lozinka{" "}
          <img
            className="toogle__password--register"
            alt="Toogle Password"
            src={TooglePassword}
            onClick={() => handleTooglePassword(1)}
          />
        </label>
        <input
          className="form__input--register password1"
          required
          min="4"
          max="12"
          type="password"
          onChange={passwordHanlder}
          value={user.password}
        />

        <label className="form__label--register">
          Potvrdi lozinku{" "}
          <img
            className="toogle__password--register"
            alt="Toogle Password"
            src={TooglePassword}
            onClick={() => handleTooglePassword(2)}
          />
        </label>
        <input
          className="form__input--register password2"
          required
          type="password"
          onChange={repatedPasswordHandler}
          value={repatedPassword}
        />

        <p>{backendMessage}</p>

        <button className="form__submit--register" type="submit">
          Registriraj se
        </button>
      </form>
      <Link to="/login">
        <p className="login">Već imaš račun? Prijavi se.</p>
      </Link>
    </section>
  );
};

export default Register;
