import axios from "axios";

export const newToken = (token) =>
  axios.get(`api/Account/RefreshToken?token=${token}`);
