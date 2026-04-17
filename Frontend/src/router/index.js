import { createRouter, createWebHistory } from "vue-router";
import UsersList from "../views/UsersList.vue";
import CreateUser from "../views/CreateUser.vue";
import EditUser from "../views/EditUser.vue";

const routes = [
  { path: "/", component: UsersList },
  { path: "/create", component: CreateUser },
  { path: "/edit/:id", component: EditUser },
];

export default createRouter({
  history: createWebHistory(),
  routes,
});