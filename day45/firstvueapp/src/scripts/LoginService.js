import axios from "axios";

export function login(email, password) {
    return axios.post('http://localhost:5243/api/User/Login', {
      "userName": email,
      "password": password
    });
  }
