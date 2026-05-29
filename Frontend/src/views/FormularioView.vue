<template>
  <div class="min-h-screen bg-gray-50">
    <!-- Header -->
    <div class="bg-white shadow-sm border-b border-gray-200 sticky top-0 z-10">
      <div class="max-w-4xl mx-auto px-4 py-4 flex items-center justify-between">
        <div>
          <h1 class="text-2xl font-bold text-red-600">
            {{ isEditing ? 'Editar Formulário' : 'Novo Formulário' }}
          </h1>
        </div>
        <RouterLink to="/home" class="text-red-600 hover:text-red-700 font-medium text-sm">
          ← Voltar
        </RouterLink>
      </div>
    </div>

    <!-- Content -->
    <div class="max-w-4xl mx-auto px-4 py-8">
      <form @submit.prevent="handleSubmit" class="space-y-6">
        <!-- Seção 1: Dados Institucionais -->
        <div class="card">
          <h2 class="text-lg font-bold text-gray-900 mb-4 pb-4 border-b border-gray-200">
            📋 Dados Institucionais
          </h2>

          <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div>
              <label class="block text-sm font-medium text-gray-700 mb-1">
                Nome da Contratada *
              </label>
              <input
                v-model="form.nomeContratada"
                type="text"
                class="input-field"
                required
              />
            </div>

            <div>
              <label class="block text-sm font-medium text-gray-700 mb-1">
                Número do Contrato *
              </label>
              <input
                v-model="form.numeroContrato"
                type="text"
                class="input-field"
                required
              />
            </div>
          </div>
        </div>

        <!-- Seção 2: Caracterização -->
        <div class="card">
          <h2 class="text-lg font-bold text-gray-900 mb-4 pb-4 border-b border-gray-200">
            📍 Caracterização
          </h2>

          <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div>
              <label class="block text-sm font-medium text-gray-700 mb-1">
                Linha CPTM *
              </label>
              <input
                v-model="form.linhaCptm"
                type="text"
                class="input-field"
                required
              />
            </div>

            <div>
              <label class="block text-sm font-medium text-gray-700 mb-1">
                Via CPTM *
              </label>
              <input
                v-model="form.viaCptm"
                type="text"
                class="input-field"
                required
              />
            </div>

            <div>
              <label class="block text-sm font-medium text-gray-700 mb-1">
                Município *
              </label>
              <input
                v-model="form.municipio"
                type="text"
                class="input-field"
                required
              />
            </div>

            <div>
              <label class="block text-sm font-medium text-gray-700 mb-1">
                Endereço
              </label>
              <input
                v-model="form.endereco"
                type="text"
                class="input-field"
              />
            </div>
          </div>

          <!-- Geolocalização -->
          <div class="mt-4 pt-4 border-t border-gray-200">
            <div class="flex items-center justify-between mb-4">
              <label class="block text-sm font-medium text-gray-700">
                Coordenadas Geográficas
              </label>
              <button
                type="button"
                @click="handleGetLocation"
                :disabled="isGettingLocation"
                class="btn btn-sm bg-red-50 text-red-600 hover:bg-red-100"
              >
                {{ isGettingLocation ? '⏳ Localizando...' : '📍 Obter Localização' }}
              </button>
            </div>

            <input
              v-model="form.coordenadaGeografica"
              type="text"
              class="input-field"
              placeholder="Latitude, Longitude"
            />

            <div v-if="locationAccuracy" class="text-xs text-gray-600 mt-2">
              Precisão: ±{{ locationAccuracy }}m
            </div>
          </div>
        </div>

        <!-- Seção 3: Informações Ambientais -->
        <div class="card">
          <h2 class="text-lg font-bold text-gray-900 mb-4 pb-4 border-b border-gray-200">
            🌍 Informações Ambientais
          </h2>

          <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div>
              <label class="block text-sm font-medium text-gray-700 mb-1">
                Tipo de Efluente *
              </label>
              <select v-model="form.tipoEfluente" class="input-field" required>
                <option value="">Selecione um tipo</option>
                <option value="Doméstico">Doméstico</option>
                <option value="Industrial">Industrial</option>
                <option value="Agrícola">Agrícola</option>
                <option value="Misto">Misto</option>
                <option value="Outro">Outro</option>
              </select>
            </div>

            <div>
              <label class="block text-sm font-medium text-gray-700 mb-1">
                Status do Desvio Ambiental *
              </label>
              <select v-model="form.statusDesvioAmbiental" class="input-field" required>
                <option value="">Selecione um status</option>
                <option value="Conforme">Conforme</option>
                <option value="Não Conforme">Não Conforme</option>
                <option value="Crítico">Crítico</option>
                <option value="Em Análise">Em Análise</option>
              </select>
            </div>
          </div>

          <div class="mt-4">
            <label class="block text-sm font-medium text-gray-700 mb-1">
              Observações
            </label>
            <textarea
              v-model="form.observacao"
              class="input-field"
              rows="4"
              placeholder="Digite observações relevantes..."
            ></textarea>
          </div>
        </div>

        <!-- Error Message -->
        <div v-if="error" class="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded-lg">
          {{ error }}
        </div>

        <!-- Status Message -->
        <div v-if="!isOnline" class="bg-yellow-50 border border-yellow-200 text-yellow-700 px-4 py-3 rounded-lg">
          ⚠️ Você está offline. O formulário será sincronizado quando voltar online.
        </div>

        <!-- Submit Buttons -->
        <div class="flex flex-col sm:flex-row gap-3">
          <button
            type="submit"
            :disabled="efluenteStore.isLoading"
            class="btn-primary flex-1 disabled:opacity-50"
          >
            {{ efluenteStore.isLoading ? 'Salvando...' : 'Salvar Formulário' }}
          </button>
          <RouterLink
            to="/home"
            class="btn bg-gray-200 text-gray-700 hover:bg-gray-300 flex-1 text-center"
          >
            Cancelar
          </RouterLink>
        </div>
      </form>
    </div>
  </div>
</template>

<script setup>
import { ref, reactive, onMounted } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { useEfluenteStore } from '../stores/efluenteStore'
import { geoService } from '../services/geoService'

const router = useRouter()
const route = useRoute()
const efluenteStore = useEfluenteStore()

const isEditing = ref(false)
const isOnline = ref(navigator.onLine)
const isGettingLocation = ref(false)
const locationAccuracy = ref(null)
const error = ref('')

const form = reactive({
  nomeContratada: '',
  numeroContrato: '',
  linhaCptm: '',
  viaCptm: '',
  municipio: '',
  endereco: '',
  coordenadaGeografica: '',
  tipoEfluente: '',
  statusDesvioAmbiental: '',
  observacao: ''
})

onMounted(async () => {
  window.addEventListener('online', () => {
    isOnline.value = true
  })
  window.addEventListener('offline', () => {
    isOnline.value = false
  })

  // Se estiver editando, carregar dados
  if (route.params.id && route.params.id !== 'novo') {
    isEditing.value = true
    try {
      const efluente = await efluenteStore.getEfluenteById(route.params.id)
      if (efluente) {
        Object.assign(form, efluente)
      }
    } catch (err) {
      error.value = 'Erro ao carregar formulário'
    }
  }
})

async function handleGetLocation() {
  isGettingLocation.value = true
  error.value = ''

  try {
    const location = await geoService.getCurrentLocation()
    form.coordenadaGeografica = location.coordenadaGeografica
    locationAccuracy.value = Math.round(location.accuracy)
  } catch (err) {
    error.value = `Erro ao obter localização: ${err.message}`
  } finally {
    isGettingLocation.value = false
  }
}

async function handleSubmit() {
  error.value = ''

  try {
    if (isEditing.value) {
      await efluenteStore.updateEfluente(route.params.id, form)
    } else {
      await efluenteStore.createEfluente(form)
    }

    router.push('/home')
  } catch (err) {
    error.value = err.message || 'Erro ao salvar formulário'
  }
}
</script>