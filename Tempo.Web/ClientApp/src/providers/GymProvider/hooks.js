import { useContext } from "react";
import { GymContext } from ".";

const useGymContext = () => {
  return useContext(GymContext);
};

export const useGyms = () => {
  const {
    state: { gyms },
    setGyms,
  } = useGymContext();

  return [gyms, setGyms];
};
