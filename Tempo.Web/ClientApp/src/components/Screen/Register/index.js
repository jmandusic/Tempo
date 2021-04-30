import axios from "axios";
import { useState } from "react";
import { Link, useHistory } from "react-router-dom";
import { parseJwt } from "../../../utils/jwtHelper";

const Register = () => {
  const [role, setRole] = useState(null);
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

  const handleSubmit = (e) => {
    e.preventDefault();

    if (user.password !== repatedPassword) {
      return;
    }

    axios.post("api/Account/RegisterRegularUser", user).then(
      (res) => {
        localStorage.setItem("token", res.data);
        const parsedToken = parseJwt(res.data);
        setRole(parsedToken.role);
      },
      ({ response }) => {
        setBackendMessage(response.data);
      }
    );
  };

  if (role) {
    return <Redirect to={`/home/${role.toLowerCase()}`} />;
  }

  return (
    <section>
      <form onSubmit={handleSubmit}>
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

        <p>{backendMessage}</p>

        <button type="submit">Registriraj se</button>
      </form>
      <Link to="/login">
        <p>Već imaš račun? Prijavi se.</p>
      </Link>
    </section>
  );
};

export default Register;
