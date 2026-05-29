import api from './api'

export const authService = {
  async login(email, password) {
    const response = await api.post('/api/auth/login', {
      email,
      password
    })
    return response.data
  },

  async forgotPassword(email) {
    const response = await api.post('/api/auth/forgot-password', {
      email
    })
    return response.data
  },

  async resetPassword(token, newPassword) {
    const response = await api.post('/api/auth/reset-password', {
      token,
      newPassword
    })
    return response.data
  },

  async getCurrentUser() {
    const response = await api.get('/api/users/me')
    return response.data
  },

  async updateProfile(name, email, currentPassword) {
    const response = await api.put('/api/users/me', {
      name,
      email,
      currentPassword
    })
    return response.data
  },

  async updatePassword(currentPassword, newPassword) {
    const response = await api.put('/api/users/me/password', {
      currentPassword,
      newPassword
    })
    return response.data
  },

  async deleteAccount() {
    const response = await api.delete('/api/users/me')
    return response.data
  }
}
