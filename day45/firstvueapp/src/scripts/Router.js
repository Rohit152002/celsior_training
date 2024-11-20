import AddProductComponent from "@/components/AddProductComponent.vue";
import HelloWorld from "@/components/HelloWorld.vue";
import LoginComponent from "@/components/LoginComponent.vue";

import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    path: "/",
    component: HelloWorld,
    beforeEnter: (to, from, next) => {
      if (sessionStorage.getItem("token")) {
        next();
      } else {
        next("/login");
      }
    },
  },
  { path: "/login", component: LoginComponent },
  {
    path: "/products",
    component: AddProductComponent,
    beforeEnter: (to, from, next) => {
      if (sessionStorage.getItem("token")) {
        next();
      } else {
        next("/login");
      }
    },
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
