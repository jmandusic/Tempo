import axios from "axios";

export const newToken = (token) =>
  axios.get(`api/Account/RefreshToken?token=${token}`);

export const getGyms = async () => {
  const response = await axios.get("api/Gym/GetAllGyms");
    if (response.status === 200) {
       return response.data;
    }
};
