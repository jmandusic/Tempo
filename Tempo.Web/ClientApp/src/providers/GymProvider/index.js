import { createContext, useState } from "react";
import { getAllGyms } from "../../services/data";

const initialState = {
  gyms: getAllGyms(),
};

export const GymContext = createContext({
  state: { ...initialState },
  setState: () => {},
});

const GymProvider = ({ children }) => {
  const [gyms, setGyms] = useState(initialState);

  const value = {
    state: gyms,
    setGyms,
  };

  return <GymContext.Provider value={value}>{children}</GymContext.Provider>;
};

export default GymProvider;
