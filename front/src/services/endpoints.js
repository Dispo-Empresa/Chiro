const LOCALHOST = `https://localhost:7170/api/v1/`;

const ENDPOINTS = {
  auth: {
    base: `auth`,
    authenticate: `auth/authenticate`,
  },
  boardAction: {
    base: `board-action`,
    changeColor: `board-action/change-color`,
    resize: `board-action/resize`,
    move: `board-action/move`,
    changePeriod: `board-action/change-period`,
    conclude: `board-action/conclude`,
    link: `board-action/link`,
  },
  project: {
    base: `project`,
    getById: (id) => `project/${id}`,
    changeColor: `project/change-color`,
    resize: `project/resize`,
    move: `project/move`,
  },
};

export { LOCALHOST, ENDPOINTS };
