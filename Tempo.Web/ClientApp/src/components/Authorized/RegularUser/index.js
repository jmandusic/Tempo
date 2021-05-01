import { useEffect, useState } from "react";
import { useGyms } from "../../../providers/GymProvider/hooks";
import { useUser } from "../../../providers/UserProvider/hooks";
import axios from "axios";

const RegularUser = () => {
  const [gyms, setGyms] = useGyms();
  const [{ role, userId }, setState] = useUser();
  const [user, setUser] = useState({});

  useEffect(() => {
    axios
      .get(`api/Account/GetUser?userId=${userId}`)
      .then((res) => {
        setUser(res.data);
      })
      .catch((err) => {
        alert("Fething user unsuccesfull");
      });
  }, []);

  if (!user) {
    return <div>Loading...</div>;
  }

  return <div>{user.name}</div>;
};

export default RegularUser;
