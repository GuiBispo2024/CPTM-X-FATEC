import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Stations from '../views/Stations.vue'
import Inspecao from '../views/Inspection.vue'

const routes = [
  { path: '/', component: Home },
  { path: '/login', component: Login },
  { path: '/stations', component: Stations },
  { path: '/inspection', component: Inspecao }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router