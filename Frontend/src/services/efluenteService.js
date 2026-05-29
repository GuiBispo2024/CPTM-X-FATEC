import api from './api'

export const efluenteService = {
  async getAll() {
    const response = await api.get('/api/efluentes')
    return response.data
  },

  async getById(id) {
    const response = await api.get(`/api/efluentes/${id}`)
    return response.data
  },

  async create(data) {
    const response = await api.post('/api/efluentes', data)
    return response.data
  },

  async update(id, data) {
    const response = await api.put(`/api/efluentes/${id}`, data)
    return response.data
  },

  async delete(id) {
    const response = await api.delete(`/api/efluentes/${id}`)
    return response.data
  },

  async getPendingSync() {
    const response = await api.get('/api/efluentes/pending-sync')
    return response.data
  }
}
