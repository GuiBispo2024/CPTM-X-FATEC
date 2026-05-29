import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import { authService } from '../services/authService'
import { dbService } from '../services/dbService'

export const useAuthStore = defineStore('auth', () => {
  const token = ref(null)
  const user = ref(null)
  const isLoading = ref(false)
  const error = ref(null)

  const isAuthenticated = computed(() => !!token.value)

  async function initializeAuth() {
    try {
      const savedToken = await dbService.getAuthToken()
      if (savedToken) {
        token.value = savedToken
        await fetchCurrentUser()
      }
    } catch (err) {
      console.error('Erro ao inicializar autenticação:', err)
    }
  }

  async function login(email, password) {
    isLoading.value = true
    error.value = null

    try {
      const response = await authService.login(email, password)
      token.value = response.token
      await dbService.saveAuthToken(response.token)
      await fetchCurrentUser()
      return true
    } catch (err) {
      error.value = err.response?.data?.message || 'Erro ao fazer login'
      return false
    } finally {
      isLoading.value = false
    }
  }

  async function fetchCurrentUser() {
    try {
      user.value = await authService.getCurrentUser()
    } catch (err) {
      console.error('Erro ao buscar usuário atual:', err)
      logout()
    }
  }

  async function updateProfile(name, email, currentPassword) {
    isLoading.value = true
    error.value = null

    try {
      await authService.updateProfile(name, email, currentPassword)
      await fetchCurrentUser()
      return true
    } catch (err) {
      error.value = err.response?.data?.message || 'Erro ao atualizar perfil'
      return false
    } finally {
      isLoading.value = false
    }
  }

  async function updatePassword(currentPassword, newPassword) {
    isLoading.value = true
    error.value = null

    try {
      await authService.updatePassword(currentPassword, newPassword)
      return true
    } catch (err) {
      error.value = err.response?.data?.message || 'Erro ao atualizar senha'
      return false
    } finally {
      isLoading.value = false
    }
  }

  async function logout() {
    token.value = null
    user.value = null
    await dbService.clearAuthToken()
  }

  return {
    token,
    user,
    isLoading,
    error,
    isAuthenticated,
    initializeAuth,
    login,
    fetchCurrentUser,
    updateProfile,
    updatePassword,
    logout
  }
})
