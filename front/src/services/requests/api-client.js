import axios from "axios";

const BASE_URL =
  process.env.REACT_APP_BASE_URL || `https://localhost:7170/api/v1`;

const apiClient = axios.create({
  baseURL: BASE_URL,
  headers: {
    "Content-Type": "application/json",
    "Authorization": `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MjAxNDQ4NDksImlzcyI6ImRpc3BvQGdtYWlsLmNvbSIsImF1ZCI6ImRpc3BvQGdtYWlsLmNvbSJ9.TW4Pb1YeA4-DYnj6z6C8GcrHl3aa3sVTP4mYRQep1sc`
  },
});

const useGet = (url, config = {}) => {
  return apiClient.get(url, config);
};

const useDelete = (url, config = {}) => {
  return apiClient.delete(url, config);
};

const usePut = (url, data = {}, config = {}) => {
  return apiClient.put(url, data, config);
};

const usePost = (url, data = {}, config = {}) => {
  return apiClient.post(url, data, config);
};

export { useGet, useDelete, usePut, usePost };
