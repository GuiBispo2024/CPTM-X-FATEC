<template>
  <div class="fixed bottom-4 right-4 z-50">
    <!-- Sync Status Badge -->
    <div
      v-if="showStatus"
      :class="[
        'flex items-center gap-2 px-4 py-3 rounded-lg shadow-lg text-white text-sm font-medium',
        statusClass
      ]"
    >
      <span v-if="isSyncing" class="inline-block animate-spin-slow">⏳</span>
      <span v-else-if="lastSyncSuccess" class="text-lg">✓</span>
      <span v-else class="text-lg">⚠️</span>
      {{ statusMessage }}
    </div>
  </div>
</template>

<script setup>
import { ref, computed, onMounted, onUnmounted } from 'vue'
import { useEfluenteStore } from '../stores/efluenteStore'
import { syncService } from '../services/syncService'

const efluenteStore = useEfluenteStore()
const isSyncing = ref(false)
const showStatus = ref(false)
const lastSyncSuccess = ref(true)
let statusTimeout = null
let syncCheckInterval = null

const statusMessage = computed(() => {
  if (isSyncing.value) {
    return 'Sincronizando...'
  }
  if (lastSyncSuccess.value) {
    return 'Sincronizado com sucesso'
  }
  return 'Erro na sincronização'
})

const statusClass = computed(() => {
  if (isSyncing.value) {
    return 'bg-blue-500'
  }
  if (lastSyncSuccess.value) {
    return 'bg-green-500'
  }
  return 'bg-red-500'
})

async function checkAndSync() {
  if (!navigator.onLine) return

  const pending = efluenteStore.pendingEfluentes.length
  if (pending === 0) return

  isSyncing.value = true
  try {
    await efluenteStore.syncPendingEfluentes()
    lastSyncSuccess.value = true
    showStatus.value = true

    statusTimeout = setTimeout(() => {
      showStatus.value = false
    }, 3000)
  } catch (err) {
    lastSyncSuccess.value = false
    showStatus.value = true
  } finally {
    isSyncing.value = false
  }
}

onMounted(() => {
  // Sincronizar quando voltar online
  window.addEventListener('online', checkAndSync)

  // Verificar periodicamente
  syncCheckInterval = setInterval(checkAndSync, 30000)
})

onUnmounted(() => {
  window.removeEventListener('online', checkAndSync)
  clearInterval(syncCheckInterval)
  clearTimeout(statusTimeout)
})
</script>
