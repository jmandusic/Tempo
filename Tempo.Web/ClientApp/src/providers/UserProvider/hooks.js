import { useContext } from "react";
import { UserContext } from ".";

const useUserContext = () => {
  return useContext(UserContext);
};

export const useUser = () => {
    const {
        state: { role, userId },
        logOut,
    } = useContext(UserContext);

  return [{ role, userId }, logOut];
};
 