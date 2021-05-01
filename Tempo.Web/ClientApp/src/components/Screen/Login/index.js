import { Link, Redirect, useHistory } from "react-router-dom";
import axios from "axios";
import { useState } from "react";
import { parseJwt } from "../../../utils/jwtHelper";
import { useUser } from "../../../providers/UserProvider/hooks";

const Login = () => {
  const [{role, userId}, setState] = useUser();
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
    <section>
      <form onSubmit={handleSubmit}>
        <label>Email</label>
        <input type="email" value={user.email} onChange={emailHanlder} />

        <label>Password</label>
        <input
          type="password"
          value={user.password}
          onChange={passwordHanlder}
        />

        <p>{backendMessage}</p>

        <button type="submit">Log in</button>
      </form>
      <Link to="/register">
        <p>Još uvijek nemaš račun? Registriraj se.</p>
      </Link>
    </section>
  );
};

export default Login;
