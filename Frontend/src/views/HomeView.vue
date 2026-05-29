<template>
  <div class="min-h-screen bg-gray-50">
    <!-- Header -->
    <div class="bg-white shadow-sm border-b border-gray-200 sticky top-0 z-10">
      <div class="max-w-6xl mx-auto px-4 py-4 flex items-center justify-between">
        <div>
          <h1 class="text-2xl font-bold text-red-600">CPTM Field</h1>
          <p class="text-sm text-gray-600">Bem-vindo, {{ authStore.user?.name }}</p>
        </div>
        <div class="flex items-center gap-4">
          <!-- Status Badge -->
          <div class="flex items-center gap-2">
            <div :class="['w-3 h-3 rounded-full', isOnline ? 'bg-green-500' : 'bg-red-500']"></div>
            <span class="text-sm font-medium text-gray-600">
              {{ isOnline ? 'Online' : 'Offline' }}
            </span>
          </div>

          <!-- Menu -->
          <div class="relative">
            <button
              @click="showMenu = !showMenu"
              class="p-2 hover:bg-gray-100 rounded-lg transition-colors"
            >
              ⋮
            </button>
            <div
              v-if="showMenu"
              class="absolute right-0 mt-2 w-48 bg-white rounded-lg shadow-lg border border-gray-200 py-2"
            >
              <RouterLink
                to="/perfil"
                class="block px-4 py-2 text-gray-700 hover:bg-gray-50 text-sm"
              >
                Meu Perfil
              </RouterLink>
              <button
                @click="handleLogout"
                class="w-full text-left px-4 py-2 text-red-600 hover:bg-red-50 text-sm"
              >
                Sair
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Content -->
    <div class="max-w-6xl mx-auto px-4 py-8">
      <!-- Action Bar -->
      <div class="flex flex-col sm:flex-row items-start sm:items-center justify-between gap-4 mb-8">
        <div>
          <h2 class="text-xl font-bold text-gray-900">Formulários de Captação</h2>
          <p class="text-sm text-gray-600 mt-1">
            {{ efluenteStore.sortedEfluentes.length }} formulário(s) registrado(s)
          </p>
        </div>
        <div class="flex flex-col sm:flex-row gap-2 w-full sm:w-auto">
          <!-- Sync Button -->
          <button
            v-if="efluenteStore.pendingEfluentes.length > 0"
            @click="handleSync"
            :disabled="isSyncing"
            class="btn-secondary flex items-center justify-center gap-2 text-sm"
          >
            <span v-if="isSyncing" class="inline-block animate-spin-slow">⏳</span>
            {{ isSyncing ? 'Sincronizando...' : `Sincronizar (${efluenteStore.pendingEfluentes.length})` }}
          </button>

          <!-- New Form Button -->
          <RouterLink
            to="/formulario/novo"
            class="btn-primary flex items-center justify-center gap-2 text-sm"
          >
            + Novo Formulário
          </RouterLink>
        </div>
      </div>

      <!-- Pending Sync Notice -->
      <div v-if="efluenteStore.pendingEfluentes.length > 0" class="bg-yellow-50 border border-yellow-200 text-yellow-700 px-4 py-3 rounded-lg mb-6 text-sm">
        ⚠️ Você tem {{ efluenteStore.pendingEfluentes.length }} formulário(s) aguardando sincronização.
        {{ isOnline ? 'Clique em sincronizar para enviar.' : 'Eles serão sincronizados quando você voltar online.' }}
      </div>

      <!-- Loading State -->
      <div v-if="efluenteStore.isLoading" class="flex items-center justify-center py-12">
        <div class="text-center">
          <div class="inline-block animate-spin-slow text-4xl mb-4">⏳</div>
          <p class="text-gray-600">Carregando formulários...</p>
        </div>
      </div>

      <!-- Error State -->
      <div v-else-if="efluenteStore.error" class="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded-lg">
        {{ efluenteStore.error }}
      </div>

      <!-- Empty State -->
      <div v-else-if="efluenteStore.sortedEfluentes.length === 0" class="text-center py-12">
        <div class="text-6xl mb-4">📋</div>
        <h3 class="text-xl font-bold text-gray-900 mb-2">Nenhum formulário registrado</h3>
        <p class="text-gray-600 mb-6">Comece criando um novo formulário de captação ambiental.</p>
        <RouterLink
          to="/formulario/novo"
          class="btn-primary inline-flex items-center gap-2"
        >
          + Criar Primeiro Formulário
        </RouterLink>
      </div>

      <!-- Forms List -->
      <div v-else class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
        <div
          v-for="efluente in efluenteStore.sortedEfluentes"
          :key="efluente.syncId || efluente.id"
          class="card-hover group"
          @click="navigateToForm(efluente)"
        >
          <!-- Header -->
          <div class="flex items-start justify-between mb-3">
            <div class="flex-1">
              <h3 class="font-bold text-gray-900 text-lg group-hover:text-red-600 transition-colors">
                {{ efluente.nomeContratada }}
              </h3>
              <p class="text-sm text-gray-600">{{ efluente.municipio }}</p>
            </div>
            <div :class="['badge', getStatusBadgeClass(efluente.syncStatus)]">
              {{ getStatusLabel(efluente.syncStatus) }}
            </div>
          </div>

          <!-- Info Grid -->
          <div class="grid grid-cols-2 gap-2 mb-3 text-sm">
            <div>
              <p class="text-gray-600">Contrato</p>
              <p class="font-medium text-gray-900">{{ efluente.numeroContrato }}</p>
            </div>
            <div>
              <p class="text-gray-600">Linha</p>
              <p class="font-medium text-gray-900">{{ efluente.linhaCptm }}</p>
            </div>
            <div>
              <p class="text-gray-600">Tipo</p>
              <p class="font-medium text-gray-900">{{ efluente.tipoEfluente }}</p>
            </div>
            <div>
              <p class="text-gray-600">Status</p>
              <p class="font-medium text-gray-900">{{ efluente.statusDesvioAmbiental }}</p>
            </div>
          </div>

          <!-- Date -->
          <div class="text-xs text-gray-500 border-t border-gray-200 pt-3">
            {{ formatDate(efluente.updatedAt || efluente.dataCadastro) }}
          </div>

          <!-- Actions -->
          <div class="flex gap-2 mt-3 opacity-0 group-hover:opacity-100 transition-opacity">
            <RouterLink
              :to="`/formulario/${efluente.syncId || efluente.id}`"
              class="btn btn-sm bg-red-50 text-red-600 hover:bg-red-100 flex-1"
            >
              Editar
            </RouterLink>
            <button
              @click.stop="handleDelete(efluente)"
              class="btn btn-sm bg-red-50 text-red-600 hover:bg-red-100"
            >
              🗑️
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted, onUnmounted } from 'vue'
import { useRouter } from 'vue-router'
import { useAuthStore } from '../stores/authStore'
import { useEfluenteStore } from '../stores/efluenteStore'
import { syncService } from '../services/syncService'

const router = useRouter()
const authStore = useAuthStore()
const efluenteStore = useEfluenteStore()
const showMenu = ref(false)
const isOnline = ref(navigator.onLine)
const isSyncing = ref(false)

onMounted(async () => {
  await efluenteStore.fetchEfluentes()

  window.addEventListener('online', () => {
    isOnline.value = true
    handleSync()
  })
  window.addEventListener('offline', () => {
    isOnline.value = false
  })
})

onUnmounted(() => {
  window.removeEventListener('online', () => {
    isOnline.value = true
  })
  window.removeEventListener('offline', () => {
    isOnline.value = false
  })
})

function navigateToForm(efluente) {
  router.push(`/formulario/${efluente.syncId || efluente.id}`)
}

async function handleSync() {
  isSyncing.value = true
  try {
    await efluenteStore.syncPendingEfluentes()
  } finally {
    isSyncing.value = false
  }
}

async function handleDelete(efluente) {
  if (!confirm('Tem certeza que deseja deletar este formulário?')) {
    return
  }

  try {
    await efluenteStore.deleteEfluente(efluente.syncId || efluente.id)
  } catch (err) {
    alert('Erro ao deletar formulário')
  }
}

function handleLogout() {
  authStore.logout()
  router.push('/login')
}

function formatDate(dateString) {
  const date = new Date(dateString)
  return date.toLocaleDateString('pt-BR', {
    day: '2-digit',
    month: '2-digit',
    year: 'numeric',
    hour: '2-digit',
    minute: '2-digit'
  })
}

function getStatusLabel(status) {
  const labels = {
    'PENDING': '⏳ Pendente',
    'SYNCED': '✓ Sincronizado',
    'ERROR': '✗ Erro'
  }
  return labels[status] || status
}

function getStatusBadgeClass(status) {
  const classes = {
    'PENDING': 'badge-warning',
    'SYNCED': 'badge-success',
    'ERROR': 'badge-danger'
  }
  return classes[status] || 'badge-info'
}
</script>