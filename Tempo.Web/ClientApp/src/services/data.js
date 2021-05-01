import axios from "axios";

export const getAllGyms = () => {
  let gyms = [];
  axios
    .get("api/Gym/GetAllGyms")
    .then((res) => {
      gyms = res.data;
    })
    .catch((err) => {
      alert("Fethcing gyms unsuccesful");
    });

  return  gyms;
};

