<template>
  <div class="min-h-screen bg-gradient-to-br from-red-600 to-red-800 flex items-center justify-center px-4">
    <div class="w-full max-w-md">
      <div class="bg-white rounded-lg shadow-xl p-8">
        <!-- Header -->
        <div class="text-center mb-8">
          <h1 class="text-3xl font-bold text-red-600 mb-2">Recuperar Senha</h1>
          <p class="text-gray-600">Digite seu email para receber um link de recuperação</p>
        </div>

        <!-- Form -->
        <form @submit.prevent="handleForgotPassword" class="space-y-4">
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

          <!-- Success Message -->
          <div v-if="successMessage" class="bg-green-50 border border-green-200 text-green-700 px-4 py-3 rounded-lg text-sm">
            {{ successMessage }}
          </div>

          <!-- Error Message -->
          <div v-if="authStore.error" class="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded-lg text-sm">
            {{ authStore.error }}
          </div>

          <!-- Submit Button -->
          <button
            type="submit"
            :disabled="authStore.isLoading || !!successMessage"
            class="btn-primary w-full disabled:opacity-50 disabled:cursor-not-allowed"
          >
            <span v-if="authStore.isLoading" class="inline-block animate-spin-slow mr-2">⏳</span>
            {{ authStore.isLoading ? 'Enviando...' : 'Enviar Link' }}
          </button>
        </form>

        <!-- Links -->
        <div class="mt-6 text-center text-sm border-t border-gray-200 pt-6 space-y-2">
          <div>
            <RouterLink to="/login" class="text-red-600 hover:text-red-700 font-medium">
              Voltar ao login
            </RouterLink>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { reactive, ref } from 'vue'
import { useAuthStore } from '../stores/authStore'
import { authService } from '../services/authService'

const authStore = useAuthStore()
const successMessage = ref('')

const form = reactive({
  email: ''
})

async function handleForgotPassword() {
  authStore.error = null
  successMessage.value = ''

  try {
    authStore.isLoading = true
    await authService.forgotPassword(form.email)
    successMessage.value = 'Se o email existir em nosso sistema, você receberá um link de recuperação em breve.'
  } catch (err) {
    authStore.error = err.response?.data?.message || 'Erro ao enviar email'
  } finally {
    authStore.isLoading = false
  }
}
</script>