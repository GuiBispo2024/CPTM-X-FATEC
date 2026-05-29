<template>
  <div class="min-h-screen bg-gray-50">
    <!-- Header -->
    <div class="bg-white shadow-sm border-b border-gray-200">
      <div class="max-w-4xl mx-auto px-4 py-6 flex items-center justify-between">
        <div>
          <h1 class="text-3xl font-bold text-red-600">Meu Perfil</h1>
          <p class="text-gray-600 mt-1">Gerencie suas informações pessoais</p>
        </div>
        <RouterLink to="/home" class="text-red-600 hover:text-red-700 font-medium">
          ← Voltar
        </RouterLink>
      </div>
    </div>

    <!-- Content -->
    <div class="max-w-4xl mx-auto px-4 py-8">
      <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
        <!-- Profile Info -->
        <div class="card">
          <h2 class="text-xl font-bold text-gray-900 mb-4">Informações Pessoais</h2>
          <div class="space-y-4">
            <div>
              <p class="text-sm text-gray-600">Nome</p>
              <p class="text-lg font-medium text-gray-900">{{ authStore.user?.name }}</p>
            </div>
            <div>
              <p class="text-sm text-gray-600">Email</p>
              <p class="text-lg font-medium text-gray-900">{{ authStore.user?.email }}</p>
            </div>
            <div>
              <p class="text-sm text-gray-600">Tipo de Usuário</p>
              <p class="text-lg font-medium text-gray-900">
                {{ authStore.user?.isAdmin ? 'Administrador' : 'Operador' }}
              </p>
            </div>
          </div>
        </div>

        <!-- Edit Profile -->
        <div class="card">
          <h2 class="text-xl font-bold text-gray-900 mb-4">Editar Perfil</h2>
          <form @submit.prevent="handleUpdateProfile" class="space-y-4">
            <div>
              <label class="block text-sm font-medium text-gray-700 mb-1">
                Nome
              </label>
              <input
                v-model="editForm.name"
                type="text"
                class="input-field"
                required
              />
            </div>

            <div>
              <label class="block text-sm font-medium text-gray-700 mb-1">
                Email
              </label>
              <input
                v-model="editForm.email"
                type="email"
                class="input-field"
                required
              />
            </div>

            <div>
              <label class="block text-sm font-medium text-gray-700 mb-1">
                Senha Atual (para confirmar)
              </label>
              <input
                v-model="editForm.currentPassword"
                type="password"
                class="input-field"
                required
              />
            </div>

            <div v-if="authStore.error" class="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded-lg text-sm">
              {{ authStore.error }}
            </div>

            <div v-if="successMessage" class="bg-green-50 border border-green-200 text-green-700 px-4 py-3 rounded-lg text-sm">
              {{ successMessage }}
            </div>

            <button
              type="submit"
              :disabled="authStore.isLoading"
              class="btn-primary w-full disabled:opacity-50"
            >
              {{ authStore.isLoading ? 'Atualizando...' : 'Atualizar Perfil' }}
            </button>
          </form>
        </div>

        <!-- Change Password -->
        <div class="card">
          <h2 class="text-xl font-bold text-gray-900 mb-4">Alterar Senha</h2>
          <form @submit.prevent="handleUpdatePassword" class="space-y-4">
            <div>
              <label class="block text-sm font-medium text-gray-700 mb-1">
                Senha Atual
              </label>
              <input
                v-model="passwordForm.currentPassword"
                type="password"
                class="input-field"
                required
              />
            </div>

            <div>
              <label class="block text-sm font-medium text-gray-700 mb-1">
                Nova Senha
              </label>
              <input
                v-model="passwordForm.newPassword"
                type="password"
                class="input-field"
                required
              />
            </div>

            <div>
              <label class="block text-sm font-medium text-gray-700 mb-1">
                Confirmar Nova Senha
              </label>
              <input
                v-model="passwordForm.confirmPassword"
                type="password"
                class="input-field"
                required
              />
            </div>

            <div v-if="passwordError" class="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded-lg text-sm">
              {{ passwordError }}
            </div>

            <div v-if="passwordSuccess" class="bg-green-50 border border-green-200 text-green-700 px-4 py-3 rounded-lg text-sm">
              {{ passwordSuccess }}
            </div>

            <button
              type="submit"
              :disabled="authStore.isLoading"
              class="btn-primary w-full disabled:opacity-50"
            >
              {{ authStore.isLoading ? 'Alterando...' : 'Alterar Senha' }}
            </button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { reactive, ref } from 'vue'
import { useRouter } from 'vue-router'
import { useAuthStore } from '../stores/authStore'

const router = useRouter()
const authStore = useAuthStore()
const successMessage = ref('')
const passwordError = ref('')
const passwordSuccess = ref('')

const editForm = reactive({
  name: authStore.user?.name || '',
  email: authStore.user?.email || '',
  currentPassword: ''
})

const passwordForm = reactive({
  currentPassword: '',
  newPassword: '',
  confirmPassword: ''
})

async function handleUpdateProfile() {
  authStore.error = null
  successMessage.value = ''

  const success = await authStore.updateProfile(
    editForm.name,
    editForm.email,
    editForm.currentPassword
  )

  if (success) {
    successMessage.value = 'Perfil atualizado com sucesso!'
    editForm.currentPassword = ''
  }
}

async function handleUpdatePassword() {
  authStore.error = null
  passwordError.value = ''
  passwordSuccess.value = ''

  if (passwordForm.newPassword !== passwordForm.confirmPassword) {
    passwordError.value = 'As senhas não coincidem'
    return
  }

  if (passwordForm.newPassword.length < 6) {
    passwordError.value = 'A nova senha deve ter no mínimo 6 caracteres'
    return
  }

  const success = await authStore.updatePassword(
    passwordForm.currentPassword,
    passwordForm.newPassword
  )

  if (success) {
    passwordSuccess.value = 'Senha alterada com sucesso!'
    passwordForm.currentPassword = ''
    passwordForm.newPassword = ''
    passwordForm.confirmPassword = ''
  } else {
    passwordError.value = authStore.error
  }
}

async function handleDeleteAccount() {
  if (!confirm('Tem certeza? Esta ação é irreversível!')) {
    return
  }

  const success = await authStore.deleteAccount()
  if (success) {
    router.push('/login')
  }
}
</script>
