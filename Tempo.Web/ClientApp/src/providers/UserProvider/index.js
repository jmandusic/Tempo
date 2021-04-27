import { useState, createContext } from "react";
import { useHistory } from "react-router";
import { parseJwt } from "../../utils/jwtHelper";

const token = localStorage.getItem("token");
const tokenParsed = parseJwt(token);

const initialState = {
    role: tokenParsed?.role,
    userId: tokenParsed?.userId,
};

export const UserContext = createContext({
  state: { ...initialState },
  logOut: () => {},
});

const UserProvider = ({ children }) => {
  const history = useHistory();
  const [role, setRole] = useState(initialState.role);
  const [userId, setUserId] = useState(initialState.userId);

  const logOut = () => {
    localStorage.removeItem("token");
    setRole(null);
    setUserId(null);
    history.push("/login");
  };

  const value = {
    state: { role, userId },
    logOut,
  };

  return <UserContext.Provider value={value}>{children}</UserContext.Provider>;
};

export default UserProvider;