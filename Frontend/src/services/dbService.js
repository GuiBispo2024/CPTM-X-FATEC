import { openDB } from 'idb'

const DB_NAME = 'cptm-field-app'
const DB_VERSION = 1

const STORES = {
  EFLUENTES: 'efluentes',
  SYNC_QUEUE: 'sync-queue',
  AUTH: 'auth'
}

let db = null

async function initDB() {
  if (db) return db

  db = await openDB(DB_NAME, DB_VERSION, {
    upgrade(db) {
      // Store para efluentes locais
      if (!db.objectStoreNames.contains(STORES.EFLUENTES)) {
        const store = db.createObjectStore(STORES.EFLUENTES, { keyPath: 'syncId' })
        store.createIndex('id', 'id', { unique: true })
        store.createIndex('syncStatus', 'syncStatus')
        store.createIndex('updatedAt', 'updatedAt')
      }

      // Store para fila de sincronização
      if (!db.objectStoreNames.contains(STORES.SYNC_QUEUE)) {
        const store = db.createObjectStore(STORES.SYNC_QUEUE, { keyPath: 'id', autoIncrement: true })
        store.createIndex('syncId', 'syncId', { unique: true })
        store.createIndex('action', 'action')
        store.createIndex('status', 'status')
        store.createIndex('timestamp', 'timestamp')
      }

      // Store para dados de autenticação
      if (!db.objectStoreNames.contains(STORES.AUTH)) {
        db.createObjectStore(STORES.AUTH, { keyPath: 'key' })
      }
    }
  })

  return db
}

// Efluentes
export const dbService = {
  async saveEfluente(efluente) {
    const db = await initDB()
    const tx = db.transaction(STORES.EFLUENTES, 'readwrite')
    await tx.store.put(efluente)
    await tx.done
  },

  async getEfluente(syncId) {
    const db = await initDB()
    return await db.get(STORES.EFLUENTES, syncId)
  },

  async getAllEfluentes() {
    const db = await initDB()
    return await db.getAll(STORES.EFLUENTES)
  },

  async getEfluentesBySyncStatus(status) {
    const db = await initDB()
    return await db.getAllFromIndex(STORES.EFLUENTES, 'syncStatus', status)
  },

  async deleteEfluente(syncId) {
    const db = await initDB()
    const tx = db.transaction(STORES.EFLUENTES, 'readwrite')
    await tx.store.delete(syncId)
    await tx.done
  },

  async updateEfluenteSyncStatus(syncId, status) {
    const db = await initDB()
    const efluente = await db.get(STORES.EFLUENTES, syncId)
    if (efluente) {
      efluente.syncStatus = status
      efluente.updatedAt = new Date().toISOString()
      const tx = db.transaction(STORES.EFLUENTES, 'readwrite')
      await tx.store.put(efluente)
      await tx.done
    }
  },

  // Fila de sincronização
  async addToSyncQueue(action, data) {
    const db = await initDB()
    const tx = db.transaction(STORES.SYNC_QUEUE, 'readwrite')
    const id = await tx.store.add({
      action,
      data,
      status: 'PENDING',
      timestamp: new Date().toISOString(),
      syncId: data.syncId || null
    })
    await tx.done
    return id
  },

  async getSyncQueue() {
    const db = await initDB()
    return await db.getAll(STORES.SYNC_QUEUE)
  },

  async getSyncQueueByStatus(status) {
    const db = await initDB()
    return await db.getAllFromIndex(STORES.SYNC_QUEUE, 'status', status)
  },

  async updateSyncQueueStatus(id, status) {
    const db = await initDB()
    const item = await db.get(STORES.SYNC_QUEUE, id)
    if (item) {
      item.status = status
      const tx = db.transaction(STORES.SYNC_QUEUE, 'readwrite')
      await tx.store.put(item)
      await tx.done
    }
  },

  async removeSyncQueueItem(id) {
    const db = await initDB()
    const tx = db.transaction(STORES.SYNC_QUEUE, 'readwrite')
    await tx.store.delete(id)
    await tx.done
  },

  // Autenticação
  async saveAuthToken(token) {
    const db = await initDB()
    const tx = db.transaction(STORES.AUTH, 'readwrite')
    await tx.store.put({ key: 'token', value: token })
    await tx.done
  },

  async getAuthToken() {
    const db = await initDB()
    const auth = await db.get(STORES.AUTH, 'token')
    return auth?.value || null
  },

  async clearAuthToken() {
    const db = await initDB()
    const tx = db.transaction(STORES.AUTH, 'readwrite')
    await tx.store.delete('token')
    await tx.done
  },

  async clearAll() {
    const db = await initDB()
    const tx = db.transaction([STORES.EFLUENTES, STORES.SYNC_QUEUE, STORES.AUTH], 'readwrite')
    await tx.objectStore(STORES.EFLUENTES).clear()
    await tx.objectStore(STORES.SYNC_QUEUE).clear()
    await tx.objectStore(STORES.AUTH).clear()
    await tx.done
  }
}
