<template>
  <div class="min-h-screen bg-gradient-to-br from-red-600 to-red-800 flex items-center justify-center px-4">
    <div class="w-full max-w-md">
      <div class="bg-white rounded-lg shadow-xl p-8">
        <!-- Logo/Header -->
        <div class="text-center mb-8">
          <h1 class="text-3xl font-bold text-red-600 mb-2">CPTM Field</h1>
          <p class="text-gray-600">Captação de Informações Ambientais</p>
        </div>

        <!-- Form -->
        <form @submit.prevent="handleLogin" class="space-y-4">
          <!-- Email -->
          <div>
            <label for="email" class="block text-sm font-medium text-gray-700 mb-1">
              Email
            </label>
            <input
              id="email"
              v-model="form.email"
              type="email"
              required
              class="input-field"
              placeholder="seu@email.com"
            />
          </div>

          <!-- Password -->
          <div>
            <label for="password" class="block text-sm font-medium text-gray-700 mb-1">
              Senha
            </label>
            <input
              id="password"
              v-model="form.password"
              type="password"
              required
              class="input-field"
              placeholder="••••••••"
            />
          </div>

          <!-- Error Message -->
          <div v-if="authStore.error" class="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded-lg text-sm">
            {{ authStore.error }}
          </div>

          <!-- Submit Button -->
          <button
            type="submit"
            :disabled="authStore.isLoading"
            class="btn-primary w-full disabled:opacity-50 disabled:cursor-not-allowed"
          >
            <span v-if="authStore.isLoading" class="inline-block animate-spin-slow mr-2">⏳</span>
            {{ authStore.isLoading ? 'Entrando...' : 'Entrar' }}
          </button>
        </form>

        <!-- Links -->
        <div class="mt-6 space-y-3 text-center text-sm">
          <div>
            <RouterLink to="/forgot-password" class="text-red-600 hover:text-red-700 font-medium">
              Esqueceu a senha?
            </RouterLink>
          </div>
        </div>

        <!-- Offline Notice -->
        <div v-if="!isOnline" class="mt-4 bg-yellow-50 border border-yellow-200 text-yellow-700 px-4 py-3 rounded-lg text-sm">
          ⚠️ Você está offline. Algumas funcionalidades podem não estar disponíveis.
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { reactive, ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import { useAuthStore } from '../stores/authStore'

const router = useRouter()
const authStore = useAuthStore()
const isOnline = ref(navigator.onLine)

const form = reactive({
  email: '',
  password: ''
})

onMounted(() => {
  window.addEventListener('online', () => {
    isOnline.value = true
  })
  window.addEventListener('offline', () => {
    isOnline.value = false
  })
})

async function handleLogin() {
  const success = await authStore.login(form.email, form.password)
  if (success) {
    router.push('/home')
  }
}
</script>