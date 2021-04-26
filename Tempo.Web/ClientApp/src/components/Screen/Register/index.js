import axios from "axios";
import { useState } from "react";
import { Link, useHistory } from "react-router-dom";
import { parseJwt } from "../../../utils/jwtHelper";

const Register = () => {
  const history = useHistory();
  const [repatedPassword, setRepeatedPassword] = useState("");
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

  const submit = (e) => {
    e.preventDefault();

    console.log(user.password);
    console.log(repatedPassword);
    if (user.password !== repatedPassword) {
      return;
    }

    axios.post("api/Account/RegisterRegularUser", user).then((res) => {
      localStorage.setItem("token", res.data);
      const parsedToken = parseJwt(res.data);
      history.push(`/home/${parsedToken.role.toLowerCase()}`);
    });
  };

  return (
    <section>
      <form onSubmit={submit}>
        <label>Name</label>
        <input required type="text" onChange={nameHanlder} value={user.name} />

        <label>Email</label>
        <input
          required
          type="email"
          onChange={emailHanlder}
          value={user.email}
        />

        <label>Password</label>
        <input
          required
          min="4"
          max="12"
          type="password"
          onChange={passwordHanlder}
          value={user.password}
        />

        <label>Repeat password</label>
        <input
          required
          type="password"
          onChange={repatedPasswordHandler}
          value={repatedPassword}
        />

        <button type="submit">Registriraj se</button>
      </form>
      <Link to="/login">
        <p>Već imaš račun? Prijavi se.</p>
      </Link>
    </section>
  );
};

export default Register;
