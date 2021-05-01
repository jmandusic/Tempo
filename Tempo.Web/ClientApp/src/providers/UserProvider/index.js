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
  setState: () => {},
});

const UserProvider = ({ children }) => {
  const [{ role, userId }, setState] = useState(initialState);

  const value = {
    state: { role, userId },
    setState,
  };

  return <UserContext.Provider value={value}>{children}</UserContext.Provider>;
};

export default UserProvider;
