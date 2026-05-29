import { dbService } from './dbService'
import { efluenteService } from './efluenteService'

let isSyncing = false

export const syncService = {
  async syncData() {
    if (isSyncing) return
    isSyncing = true

    try {
      const queue = await dbService.getSyncQueueByStatus('PENDING')

      for (const item of queue) {
        try {
          await this.processSyncItem(item)
          await dbService.updateSyncQueueStatus(item.id, 'SYNCED')
        } catch (error) {
          console.error('Erro ao sincronizar item:', error)
          await dbService.updateSyncQueueStatus(item.id, 'ERROR')
        }
      }
    } finally {
      isSyncing = false
    }
  },

  async processSyncItem(item) {
    const { action, data } = item

    switch (action) {
      case 'CREATE':
        return await efluenteService.create(data)
      case 'UPDATE':
        return await efluenteService.update(data.id, data)
      case 'DELETE':
        return await efluenteService.delete(data.id)
      default:
        throw new Error(`Ação desconhecida: ${action}`)
    }
  },

  startAutoSync(intervalMs = 30000) {
    // Sincronizar quando voltar online
    window.addEventListener('online', () => {
      console.log('Voltou online, iniciando sincronização...')
      this.syncData()
    })

    // Sincronizar periodicamente
    setInterval(() => {
      if (navigator.onLine) {
        this.syncData()
      }
    }, intervalMs)
  },

  isOnline() {
    return navigator.onLine
  }
}
