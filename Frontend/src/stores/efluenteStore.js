import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import { efluenteService } from '../services/efluenteService'
import { dbService } from '../services/dbService'
import { syncService } from '../services/syncService'

export const useEfluenteStore = defineStore('efluente', () => {
  const efluentes = ref([])
  const isLoading = ref(false)
  const error = ref(null)
  const currentEfluente = ref(null)

  const sortedEfluentes = computed(() => {
    return [...efluentes.value].sort((a, b) => {
      const dateA = new Date(b.updatedAt || b.dataCadastro)
      const dateB = new Date(a.updatedAt || a.dataCadastro)
      return dateA - dateB
    })
  })

  const pendingEfluentes = computed(() => {
    return efluentes.value.filter(e => e.syncStatus === 'PENDING')
  })

  async function fetchEfluentes() {
    isLoading.value = true
    error.value = null

    try {
      if (navigator.onLine) {
        const data = await efluenteService.getAll()
        efluentes.value = data
        // Salvar no IndexedDB
        for (const efluente of data) {
          await dbService.saveEfluente(efluente)
        }
      } else {
        // Carregar do IndexedDB
        const data = await dbService.getAllEfluentes()
        efluentes.value = data
      }
    } catch (err) {
      error.value = err.response?.data?.message || 'Erro ao buscar efluentes'
      // Tentar carregar do IndexedDB em caso de erro
      try {
        const data = await dbService.getAllEfluentes()
        efluentes.value = data
      } catch (dbErr) {
        console.error('Erro ao buscar do IndexedDB:', dbErr)
      }
    } finally {
      isLoading.value = false
    }
  }

  async function getEfluenteById(id) {
    isLoading.value = true
    error.value = null

    try {
      if (navigator.onLine) {
        const data = await efluenteService.getById(id)
        currentEfluente.value = data
        await dbService.saveEfluente(data)
      } else {
        const data = await dbService.getEfluente(id)
        currentEfluente.value = data
      }
      return currentEfluente.value
    } catch (err) {
      error.value = err.response?.data?.message || 'Erro ao buscar efluente'
      // Tentar carregar do IndexedDB
      try {
        const data = await dbService.getEfluente(id)
        currentEfluente.value = data
        return data
      } catch (dbErr) {
        console.error('Erro ao buscar do IndexedDB:', dbErr)
        return null
      }
    } finally {
      isLoading.value = false
    }
  }

  async function createEfluente(data) {
    isLoading.value = true
    error.value = null

    try {
      const syncId = crypto.randomUUID()
      const newEfluente = {
        ...data,
        syncId,
        syncStatus: 'PENDING',
        dataCadastro: new Date().toISOString(),
        createdAt: new Date().toISOString(),
        updatedAt: new Date().toISOString(),
        isDeleted: false
      }

      // Salvar localmente
      await dbService.saveEfluente(newEfluente)
      await dbService.addToSyncQueue('CREATE', newEfluente)

      efluentes.value.push(newEfluente)

      // Tentar sincronizar se online
      if (navigator.onLine) {
        try {
          const response = await efluenteService.create(data)
          newEfluente.id = response.id
          newEfluente.syncStatus = 'SYNCED'
          await dbService.saveEfluente(newEfluente)
          await dbService.updateSyncQueueStatus(newEfluente.syncId, 'SYNCED')
        } catch (syncErr) {
          console.error('Erro ao sincronizar:', syncErr)
        }
      }

      return newEfluente
    } catch (err) {
      error.value = err.message || 'Erro ao criar efluente'
      throw err
    } finally {
      isLoading.value = false
    }
  }

  async function updateEfluente(id, data) {
    isLoading.value = true
    error.value = null

    try {
      const efluente = efluentes.value.find(e => e.id === id || e.syncId === id)
      if (!efluente) {
        throw new Error('Efluente não encontrado')
      }

      const updatedEfluente = {
        ...efluente,
        ...data,
        syncStatus: 'PENDING',
        updatedAt: new Date().toISOString()
      }

      // Salvar localmente
      await dbService.saveEfluente(updatedEfluente)
      await dbService.addToSyncQueue('UPDATE', updatedEfluente)

      const index = efluentes.value.findIndex(e => e.id === id || e.syncId === id)
      if (index !== -1) {
        efluentes.value[index] = updatedEfluente
      }

      // Tentar sincronizar se online
      if (navigator.onLine && efluente.id) {
        try {
          await efluenteService.update(efluente.id, data)
          updatedEfluente.syncStatus = 'SYNCED'
          await dbService.saveEfluente(updatedEfluente)
        } catch (syncErr) {
          console.error('Erro ao sincronizar:', syncErr)
        }
      }

      return updatedEfluente
    } catch (err) {
      error.value = err.message || 'Erro ao atualizar efluente'
      throw err
    } finally {
      isLoading.value = false
    }
  }

  async function deleteEfluente(id) {
    isLoading.value = true
    error.value = null

    try {
      const efluente = efluentes.value.find(e => e.id === id || e.syncId === id)
      if (!efluente) {
        throw new Error('Efluente não encontrado')
      }

      const deletedEfluente = {
        ...efluente,
        isDeleted: true,
        syncStatus: 'PENDING',
        updatedAt: new Date().toISOString()
      }

      // Salvar localmente
      await dbService.saveEfluente(deletedEfluente)
      await dbService.addToSyncQueue('DELETE', deletedEfluente)

      efluentes.value = efluentes.value.filter(e => e.id !== id && e.syncId !== id)

      // Tentar sincronizar se online
      if (navigator.onLine && efluente.id) {
        try {
          await efluenteService.delete(efluente.id)
          await dbService.deleteEfluente(efluente.syncId)
        } catch (syncErr) {
          console.error('Erro ao sincronizar:', syncErr)
        }
      }

      return true
    } catch (err) {
      error.value = err.message || 'Erro ao deletar efluente'
      throw err
    } finally {
      isLoading.value = false
    }
  }

  async function syncPendingEfluentes() {
    try {
      await syncService.syncData()
      await fetchEfluentes()
    } catch (err) {
      error.value = err.message || 'Erro ao sincronizar'
    }
  }

  return {
    efluentes,
    isLoading,
    error,
    currentEfluente,
    sortedEfluentes,
    pendingEfluentes,
    fetchEfluentes,
    getEfluenteById,
    createEfluente,
    updateEfluente,
    deleteEfluente,
    syncPendingEfluentes
  }
})
