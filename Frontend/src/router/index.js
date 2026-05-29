import { createRouter, createWebHistory } from 'vue-router'
import { useAuthStore } from '../stores/authStore'

const routes = [
  {
    path: '/',
    redirect: '/home'
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import('../views/LoginView.vue'),
    meta: { requiresAuth: false }
  },
  {
    path: '/forgot-password',
    name: 'ForgotPassword',
    component: () => import('../views/ForgotPasswordView.vue'),
    meta: { requiresAuth: false }
  },
  {
    path: '/home',
    name: 'Home',
    component: () => import('../views/HomeView.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/formulario/novo',
    name: 'NovoFormulario',
    component: () => import('../views/FormularioView.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/formulario/:id',
    name: 'EditarFormulario',
    component: () => import('../views/FormularioView.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/perfil',
    name: 'Perfil',
    component: () => import('../views/PerfilView.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/:pathMatch(.*)*',
    name: 'NotFound',
    component: () => import('../views/NotFoundView.vue')
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

// router.beforeEach(async (to, from, next) => {
//   const authStore = useAuthStore()

//   if (to.meta.requiresAuth && !authStore.isAuthenticated) {
//     next('/login')
//   } else if (to.path === '/login'  && authStore.isAuthenticated) {
//     next('/home')
//   } else {
//     next()
//   }
// })

router.beforeEach((to, from, next) => {
  next()
})

export default router
