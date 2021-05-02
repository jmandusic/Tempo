import { useEffect, useState } from "react";
import { useUser } from "../../../providers/UserProvider/hooks";
import Map from "./Map";
import axios from "axios";
import { Redirect, Route, Switch } from "react-router";

const RegularUser = () => {
  const [{ role, userId }, setState] = useUser();
  const [user, setUser] = useState({});

  useEffect(() => {
    axios
      .get(`api/Account/GetUser?userId=${userId}`)
      .then((res) => {
        setUser(res.data);
      })
      .catch(() => {
        alert("Fething user unsuccesfull");
      });
  }, []);

  if (!user) {
    return <div>Loading...</div>;
  }

  return (
      <Map />
  );
};

export default RegularUser;
