import { useContext } from "react";
import { UserContext } from ".";

const useUserContext = () => {
  return useContext(UserContext);
};

export const useUser = () => {
  const {
    state: { role, userId },
    logOut,
  } = useUserContext();

  return [{ role, userId }, logOut];
};
