import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'
import router from './router'
import './assets/main.css'
import { useAuthStore } from './stores/authStore'
import { syncService } from './services/syncService'

const app = createApp(App)

app.use(createPinia())
app.use(router)

// Inicializar autenticação
const authStore = useAuthStore()
await authStore.initializeAuth()

// Iniciar sincronização automática
syncService.startAutoSync(30000)

// Registrar service worker para PWA
if ('serviceWorker' in navigator) {
  navigator.serviceWorker.register('/sw.js').catch(err => {
    console.log('Service Worker registration failed:', err)
  })
}

app.mount('#app')
