import { useContext } from "react";
import { UserContext } from ".";

const useUserContext = () => {
  return useContext(UserContext);
};

export const useUser = () => {
  const {
    state: { role, userId },
    setState,
  } = useUserContext();

  return [{ role, userId }, setState];
};
